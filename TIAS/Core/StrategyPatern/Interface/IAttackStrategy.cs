using TIAS.Core.Base;
using TIAS.Interface;
using TIAS.Models;

namespace TIAS.Core.StrategyPatern.Interface
{
    public interface IAttackStrategy
    {
        float Damage { get; }
        float AttackRange { get; }
        void ExecuteAttack(Unit target);
    }
}
