using CodeBase.HexLib;
using System.Collections.Generic;

namespace CodeBase.Core.Grid
{
    public interface IHexGrid
    {
        void MarkHexesVisible(object sender, IEnumerable<Hex> hexes);
        void MarkHexesInvisible(object sender, IEnumerable<Hex> hexes);
        IEnumerable<ITile> GetTiles(Hex hex);
    }
}