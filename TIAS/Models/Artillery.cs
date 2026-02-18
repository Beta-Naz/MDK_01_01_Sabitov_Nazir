using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Core.StrategyPatern;
using TIAS.Core.Structure;

namespace TIAS.Models
{
    public class Artillery : Unit
    {
        public Artillery(int id, HexCoord position, TypeAlliance typeAlliance)
         : base(id, 75, 5, position, typeAlliance)
        {
            IntializedStrategy(
                new GroundMoveStrategy(12, position),
                new SplashDamageStrategy(25, 2, 15));
        }
    }
}
