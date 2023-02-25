using CodeBase.HexLib;
using System.Collections.Generic;

public interface IHexGrid
{
    List<Tile> Tiles { get; }

    IEnumerable<Tile> GetTiles(Hex hex);
}