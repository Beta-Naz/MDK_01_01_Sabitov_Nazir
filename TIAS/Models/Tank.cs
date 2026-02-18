using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Core.StrategyPatern;
using TIAS.Core.Structure;

namespace TIAS.Models
{
    public class Tank : Unit
    {
        public Tank(int id, HexCoord position, TypeAlliance typeAlliance) 
            : base(id, 200, 45, position, typeAlliance)
        {
            IntializedStrategy(
                new GroundMoveStrategy(6, position),
                new DirectDamageStrategy(45, 1));
        }
    }
}
