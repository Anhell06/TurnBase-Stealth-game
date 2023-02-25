using CodeBase.HexLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexGrid : MonoBehaviour, IHexGrid
{
    public List<Tile> Tiles 
    {
        get 
        {
            if (_tiles == null)
            { 
                _tiles =  new List<Tile>();
                _tiles.AddRange(transform.GetComponentsInChildren<Tile>());
            }
            return _tiles;
        }
        private set
        {
            _tiles = value;
        }
    }

    private List<Tile> _tiles;

    private void Start()
    {

    }

    public IEnumerable<Tile> GetTiles(Hex hex)
    {
        return Tiles.Where(t => t.Coordinates.Equals(hex));
    }
}