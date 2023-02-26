using CodeBase.HexLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Core.Grid
{
    internal class HexGrid : MonoBehaviour, IHexGrid
    {
        public List<Tile> Tiles
        {
            get
            {
                if (_tiles == null || _tiles.Count == 0)
                {
                    _tiles = new();
                    _tiles.AddRange(transform.GetComponentsInChildren<Tile>());
                }

                return _tiles;
            }
            private set
            {
                _tiles = value;
            }
        }

        private Dictionary<object, List<Hex>> visibilityMap = new();

        private List<Tile> _tiles;

        public void MarkHexesVisible(object sender, IEnumerable<Hex> hexes)
        {
            if (!visibilityMap.ContainsKey(sender))
                visibilityMap.Add(sender, new());

            visibilityMap[sender].AddRange(hexes);

            foreach (var hex in hexes)
                foreach (var tile in GetTiles_Internal(hex))
                    tile.SetVisible();
        }

        public void MarkHexesInvisible(object sender, IEnumerable<Hex> hexes)
        {
            if (!visibilityMap.ContainsKey(sender))
                return;

            foreach (var hex in hexes)
            {
                visibilityMap[sender].Remove(hex);

                if (!visibilityMap[sender].Contains(hex))
                    foreach (var tile in GetTiles_Internal(hex))
                        tile.SetInvisible();
                    
            }
        }

        public IEnumerable<ITile> GetTiles(Hex hex)
            => Tiles.Where(t => t.Coordinates.Equals(hex));

        internal IEnumerable<Tile> GetTiles_Internal(Hex hex)
        {
#if UNITY_EDITOR
            return transform.GetComponentsInChildren<Tile>().Where(t => t.Coordinates.Equals(hex));
#else
            return Tiles.Where(t => t.Coordinates.Equals(hex));
#endif
        }
    }
}