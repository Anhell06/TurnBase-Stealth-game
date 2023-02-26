using CodeBase.HexLib;

namespace CodeBase.Core.Grid
{
    public interface ITile
    {
        Hex Coordinates { get; }
        TileType TileType { get; }
    }
}