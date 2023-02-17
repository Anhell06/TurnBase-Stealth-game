using CodeBase.HexLib;
using UnityEngine;

public class GridViewerExample : MonoBehaviour
{
    [SerializeField] private TileExample _tile;
    [SerializeField] public string _name;

    public void Start()
    {
        var layout = new Layout(OrentationType.Flat, Vector2.one, Vector2.zero);
        var grid = Hex.GetArea(Hex.Zero, 5);

        foreach (var hex in grid)
        {
            var tile = Instantiate(_tile, layout.HexToPixel(hex), Quaternion.identity);
            tile.Point.text = $"x: {hex.X}\ny: {hex.Y}\nz: {hex.Z}\n";
        }
    }
}
