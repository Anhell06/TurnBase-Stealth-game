using CodeBase.Core.Grid;
using CodeBase.HexLib;
using System.Collections.Generic;

namespace CodeBase.Character.Visability
{
    internal class CharacterVisabilityModel
    {
        public int Range { get; private set; } = 2;
        public List<Hex> VisibleHexes { get; set; } = new List<Hex>();
        public List<Hex> KnownHexes { get; private set; } = new List<Hex>();
        public List<TileType> Filter { get; private set; } = new List<TileType>();

        public CharacterVisabilityModel(List<TileType> filter, int visabilityRange)
        {
            Filter = filter;
            Range = visabilityRange;
        }
    }
}
