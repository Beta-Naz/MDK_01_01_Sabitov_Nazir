using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TIAS.Core.Enum;
using TIAS.Core.Hex;
using TIAS.Core.StrategyPatern;
using TIAS.Core.StrategyPatern.Interface;
using TIAS.Core.Structure;
using TIAS.Interface;

namespace TIAS.Core.Base
{
    public abstract class Unit : IAttack, IMovement, IHealth, IArmor
    {
        public int Id { get; set; }
        public TypeAlliance NameAlliance { get; private set; }
        private float _health;
        public float Health
        {
            get
            {
                return _health;
            }
            set
            {
                if(value < 0)
                {
                    _health = 0;
                }
                else if(value > MaxHealth)
                {
                    _health = MaxHealth;
                }
                else
                {
                    _health = value;
                }
            }
        }
        public float MaxHealth { get; private set; }
        public float Damage => AttackStrategy?.Damage ?? 0;
        public float AttackRange => AttackStrategy?.AttackRange ?? 0;
        public float Speed => MovementStrategy?.Speed ?? 0;
        public HexCoord Position => MovementStrategy.Position;
        public bool IsDead => Health < 0;
        public float Armor { get; private set; }
        public event Action OnTakeDamage;
        public Unit(int id, float maxHeahth, float armor, HexCoord position, TypeAlliance typeAlliance)
        {
            Id = id;
            Armor = armor;
            Health = maxHeahth;
            MaxHealth = maxHeahth;
            NameAlliance = typeAlliance;
        }
        protected void IntializedStrategy(IMovementStrategy movementStrategy, IAttackStrategy attackStrategy)
        {
            MovementStrategy = movementStrategy;
            AttackStrategy = attackStrategy;
        }

        protected IAttackStrategy AttackStrategy { get; private set; }
        protected IMovementStrategy MovementStrategy { get; private set; }
        public void Attack(Unit target)
        {
            if (IsDead) return;
            if (!CanAttack(target)) return;
            AttackStrategy?.ExecuteAttack(target);
        }
        public bool CanAttack(Unit target)
        {
            if(AttackStrategy == null) return false;
            if(target  == null) return false;
            float distance = HexMath.Distance(Position, target.Position);
            return AttackRange >= distance;
        }
        public void Move(HexCoord target)
        {
            if (IsDead) return;
            if (!target.Equals(Position))
            {
                MovementStrategy?.Move(target);
            }
        }

        public float ReduceDamage(float incomingDamage)
        {
            return Math.Max(1, incomingDamage - Armor);
        }

        public void TakeDamage(float damage)
        {
            if(IsDead) return;
            float reducedDamage = ReduceDamage(damage);
            Health = Math.Max(0, Health - reducedDamage);
            OnTakeDamage?.Invoke();
            if (IsDead)
            {
                OnDead();
            }
        }

        protected void OnDead()
        {
            MessageBox.Show($"Юнит под айди {Id} умер");
        }
    }
}
