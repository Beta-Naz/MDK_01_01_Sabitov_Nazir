using System.Collections.Generic;
using TIAS.Core.Base;
using TIAS.Core.Structure;

namespace TIAS.Core.Hex
{
    public class HexMap
    {
        private int _width;
        private int _height;
        private CellType[,] _cells;
        private List<Unit> _units; 
        private enum CellType
        {
            Plain, //Равнина - свободно ходить
            Mountain, //Гора - нельзя ходить
            Hill, //Холмы - можно ходить, но замедляет, также снижает урон
            Water, //Вода - нельзя в привочном ходить, но можно преобразоваться в корабль, будет добавлена если успею
            Forest, //Лес - можно ходить, но замедляет, также снижает урон
            City //Город - можно ходить, снижает немного урон артиллерии
        }
        public HexMap(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellType[width, height];
            _units = new List<Unit>();
        }
        public bool IsWithinBounds(HexCoord pos)
        {
            return pos.Q >= 0 && pos.Q < _width &&
                pos.R >= 0 && pos.R < _height;
        }
        public bool IsCellFree(HexCoord pos)
        {
            if(!IsWithinBounds(pos)) return false;
            if (_cells[pos.Q,pos.R] == CellType.Mountain || 
                _cells[pos.Q, pos.R] == CellType.Water)
            {
                return false;
            }
            foreach(var unit in _units)
            {
                if (unit.Position.Q == pos.Q && unit.Position.R == pos.R)
                {
                    return false;
                }
            }
            return true;
        }
        public Unit GetUnit(HexCoord pos)
        {
            if(IsWithinBounds(pos)) return null;
            foreach (var unit in _units)
            {
                if (unit.Position.Q == pos.Q && unit.Position.R == pos.R)
                {
                    return unit;
                }
            }
            return null;
        }
        public int GetMovementCost(HexCoord pos)
        {
            int movementCost;
            switch (_cells[pos.Q, pos.R])
            {
                case CellType.Mountain:
                    movementCost = int.MaxValue;
                    break;
                case CellType.Plain:
                    movementCost = 1;
                    break;
                case CellType.Hill:
                    movementCost = 3;
                    break;
                case CellType.Water:
                    movementCost = int.MaxValue;
                    break;
                case CellType.Forest:
                    movementCost = 2;
                    break;
                case CellType.City:
                    movementCost = 1;
                    break;
                default:
                    movementCost = 1;
                    break;

            };
            return movementCost;
        }
    }
}
