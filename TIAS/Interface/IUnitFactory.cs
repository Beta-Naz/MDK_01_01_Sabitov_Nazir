using TIAS.Core.Base;
using TIAS.Core.Enum;
using TIAS.Core.Structure;

namespace TIAS.Interface
{
    public interface IUnitFactory
    {
        Unit CreateUnit(int id, HexCoord position, UnitType type, TypeAlliance allianc);
    }
}
