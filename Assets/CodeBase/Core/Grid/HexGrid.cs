using CodeBase.HexLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public List<Tile> Tiles { get; private set; }

    private void Start()
    {
        Tiles ??= new List<Tile>();

        Tiles.AddRange(transform.GetComponentsInChildren<Tile>());
    }

    public IEnumerable<Tile> GetTiles(Hex hex)
    {
        return transform.GetComponentsInChildren<Tile>().Where(t => t.Coordinates.Equals(hex));
    }
}