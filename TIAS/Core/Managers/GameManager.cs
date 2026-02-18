using System;
using System.Collections.Generic;
using System.Linq;
using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Core.Hex;
using TIAS.Core.Models;
using TIAS.Core.Structure;

namespace TIAS.Core.Managers
{
    public enum GamePhase
    {
        PlayerTurn,
        AITurn,
        GameOver
    }

    public class GameManager
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance ?? (_instance = new GameManager());
        public HexMap CurrentMap
        {
            get => _currentMap;
            set => _currentMap = value;
        }
        public GamePhase CurrentPhase { get; private set; }
        public TypeAlliance CurrentPlayer { get; private set; }
        public Unit SelectedUnit { get; private set; }

        public List<Unit> PlayerUnits { get; private set; }
        public List<Unit> AIUnits { get; private set; }

        public event Action<GamePhase> OnPhaseChanged;
        public event Action<Unit> OnUnitSelected;
        public event Action OnTurnEnded;
        public event Action<List<string>> OnGameMessages;

        private List<string> _messages;
        private AIStrategy _aiStrategy;
        public HexMap _currentMap;

        private GameManager()
        {
            PlayerUnits = new List<Unit>();
            AIUnits = new List<Unit>();
            _messages = new List<string>();
            _aiStrategy = new BasicAIStrategy();
        }

        public void StartGame(List<Unit> allUnits)
        {
            PlayerUnits = allUnits.Where(u => u.NameAlliance == TypeAlliance.USSR).ToList();
            AIUnits = allUnits.Where(u => u.NameAlliance == TypeAlliance.Germany).ToList();
            CurrentMap = MainWindow.Instance?.Maps?[MainWindow.Instance.CurrentLevel];

            CurrentPlayer = TypeAlliance.USSR;
            CurrentPhase = GamePhase.PlayerTurn;

            ResetAllUnits();
            OnPhaseChanged?.Invoke(CurrentPhase);
            AddMessage("Игра началась! Ваш ход.");
        }

        public void SetCurrentMap(HexMap map)
        {
            CurrentMap = map;
        }

        public void SelectUnit(Unit unit)
        {
            if (CurrentPhase != GamePhase.PlayerTurn) return;
            if (unit == null || unit.IsDead) return;
            if (unit.NameAlliance != CurrentPlayer) return;
            if (!unit.CanAct())
            {
                AddMessage("Этот юнит уже использовал все действия в этом ходу!");
                return;
            }

            // Deselect previous
            if (SelectedUnit != null)
            {
                SelectedUnit.OnDeselected();
            }

            SelectedUnit = unit;
            unit.OnSelected();
            OnUnitSelected?.Invoke(unit);
            AddMessage($"Выбран юнит: {unit.UnitName}");
        }

        public void DeselectUnit()
        {
            if (SelectedUnit != null)
            {
                SelectedUnit.OnDeselected();
                SelectedUnit = null;
                OnUnitSelected?.Invoke(null);
            }
        }

        public bool MoveSelectedUnit(HexCoord target)
        {
            if (SelectedUnit == null)
            {
                AddMessage("Сначала выберите юнита!");
                return false;
            }

            if (CurrentPhase != GamePhase.PlayerTurn)
            {
                AddMessage("Сейчас не ваш ход!");
                return false;
            }

            if (SelectedUnit.HasMovedThisTurn)
            {
                AddMessage("Этот юнит уже перемещался в этом ходу!");
                DeselectUnit();
                return false;
            }

            if (!SelectedUnit.ReachablePositions.Contains(target))
            {
                AddMessage("Нельзя переместиться в эту клетку!");
                return false;
            }

            // Проверяем, свободна ли клетка
            if (!CurrentMap.IsCellFree(target))
            {
                AddMessage("Клетка занята или недоступна!");
                return false;
            }

            // Выполняем перемещение
            SelectedUnit.Move(target);
            AddMessage($"{SelectedUnit.UnitName} переместился");

            // Если юнит больше не может действовать, снимаем выделение
            if (!SelectedUnit.CanAct())
            {
                AddMessage($"{SelectedUnit.UnitName} использовал все действия");
                DeselectUnit();
            }
            else
            {
                // Обновляем подсветку после перемещения
                OnUnitSelected?.Invoke(SelectedUnit);
            }

            return true;
        }

        public bool AttackWithSelectedUnit(Unit target)
        {
            if (SelectedUnit == null)
            {
                AddMessage("Сначала выберите юнита!");
                return false;
            }

            if (CurrentPhase != GamePhase.PlayerTurn)
            {
                AddMessage("Сейчас не ваш ход!");
                return false;
            }

            if (SelectedUnit.HasAttackedThisTurn)
            {
                AddMessage("Этот юнит уже атаковал в этом ходу!");
                DeselectUnit();
                return false;
            }

            if (!SelectedUnit.CanAttack(target))
            {
                AddMessage("Нельзя атаковать эту цель!");
                return false;
            }

            if (target.NameAlliance == SelectedUnit.NameAlliance)
            {
                AddMessage("Нельзя атаковать союзника!");
                return false;
            }

            // Выполняем атаку
            float oldHealth = target.Health;
            SelectedUnit.Attack(target);

            AddMessage($"{SelectedUnit.UnitName} атаковал {target.UnitName} и нанес {oldHealth - target.Health} урона");

            if (target.IsDead)
            {
                AIUnits.Remove(target);
                AddMessage($"{target.UnitName} уничтожен!");
            }

            // Если юнит больше не может действовать, снимаем выделение
            if (!SelectedUnit.CanAct())
            {
                AddMessage($"{SelectedUnit.UnitName} использовал все действия");
                DeselectUnit();
            }
            else
            {
                // Обновляем подсветку после атаки
                OnUnitSelected?.Invoke(SelectedUnit);
            }

            return true;
        }

        public void EndTurn()
        {
            if (CurrentPhase == GamePhase.PlayerTurn)
            {
                // Проверяем, остались ли живые юниты у игрока
                if (PlayerUnits.Count(u => !u.IsDead) == 0)
                {
                    CurrentPhase = GamePhase.GameOver;
                    OnPhaseChanged?.Invoke(CurrentPhase);
                    return;
                }

                DeselectUnit();
                CurrentPhase = GamePhase.AITurn;
                CurrentPlayer = TypeAlliance.Germany;
                OnPhaseChanged?.Invoke(CurrentPhase);
                AddMessage("Ход противника...");

                // Start AI turn
                System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _aiStrategy.ExecuteTurn(this);
                    EndAITurn();
                }));
            }
        }

        private void EndAITurn()
        {
            // Проверяем, остались ли живые юниты у противника
            if (AIUnits.Count(u => !u.IsDead) == 0)
            {
                CurrentPhase = GamePhase.GameOver;
                OnPhaseChanged?.Invoke(CurrentPhase);
                return;
            }

            ResetAllUnits();
            CurrentPhase = GamePhase.PlayerTurn;
            CurrentPlayer = TypeAlliance.USSR;
            OnPhaseChanged?.Invoke(CurrentPhase);
            OnTurnEnded?.Invoke();
            AddMessage("Ваш ход!");
        }

        private void ResetAllUnits()
        {
            foreach (var unit in PlayerUnits)
            {
                unit.ResetTurn();
            }
            foreach (var unit in AIUnits)
            {
                unit.ResetTurn();
            }
        }

        public void AddMessage(string message)
        {
            _messages.Add($"[{DateTime.Now:T}] {message}");
            OnGameMessages?.Invoke(new List<string>(_messages));
        }

        public bool IsGameOver => CurrentPhase == GamePhase.GameOver;
    }

    public interface AIStrategy
    {
        void ExecuteTurn(GameManager gameManager);
    }

    public class BasicAIStrategy : AIStrategy
    {
        public void ExecuteTurn(GameManager gameManager)
        {
            var aliveAIUnits = gameManager.AIUnits.Where(u => !u.IsDead && u.CanAct()).ToList();

            foreach (var aiUnit in aliveAIUnits)
            {
                // Находим ближайшего врага
                var closestEnemy = FindClosestEnemy(aiUnit, gameManager.PlayerUnits.Where(u => !u.IsDead).ToList());

                if (closestEnemy == null) continue;

                int distance = HexMath.Distance(aiUnit.Position, closestEnemy.Position);

                // Пробуем атаковать, если в радиусе
                if (distance <= aiUnit.AttackRange && !aiUnit.HasAttackedThisTurn)
                {
                    aiUnit.Attack(closestEnemy);
                    System.Threading.Thread.Sleep(500); // Небольшая задержка для визуализации
                    continue;
                }

                // Пробуем приблизиться, если еще не двигались
                if (!aiUnit.HasMovedThisTurn)
                {
                    var moveTarget = FindBestMoveTowards(aiUnit, closestEnemy, gameManager.CurrentMap);
                    if (!moveTarget.Equals(aiUnit.Position))
                    {
                        aiUnit.Move(moveTarget);
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }

        private Unit FindClosestEnemy(Unit aiUnit, List<Unit> playerUnits)
        {
            Unit closest = null;
            int minDistance = int.MaxValue;

            foreach (var enemy in playerUnits.Where(u => !u.IsDead))
            {
                int dist = HexMath.Distance(aiUnit.Position, enemy.Position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closest = enemy;
                }
            }

            return closest;
        }

        private HexCoord FindBestMoveTowards(Unit unit, Unit target, HexMap map)
        {
            HexCoord bestMove = unit.Position;
            int bestDistance = HexMath.Distance(unit.Position, target.Position);

            foreach (var pos in unit.ReachablePositions)
            {
                int distance = HexMath.Distance(pos, target.Position);
                if (distance < bestDistance && map.IsCellFree(pos))
                {
                    bestDistance = distance;
                    bestMove = pos;
                }
            }

            return bestMove;
        }
    }
}