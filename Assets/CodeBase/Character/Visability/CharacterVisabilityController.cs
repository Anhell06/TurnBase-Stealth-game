using CodeBase.HexLib;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using static UnityEngine.UI.Image;

public class CharacterVisabilityController
{
    private readonly CharacterVisabilityView _view;
    private readonly CharacterVisabilityModel _model;
    private readonly ILayout _layout;
    private readonly IHexGrid _hexGrid;


    public CharacterVisabilityController(CharacterVisabilityView view, CharacterVisabilityModel model, ILayout layout, HexGrid hexGrid)
    {
        _view = view;
        _model = model;
        _layout = layout;
        _hexGrid = hexGrid;
    }

    public void MakeHexesVisible(Vector3 position)
    {
        var visubilityHexes = FindVisibleHexes(_layout.PixelToHex(position));
        UpdateVisibleTiles(_model.VisibleHexes, visubilityHexes);
        _model.VisibleHexes = visubilityHexes;
    }

    private List<Hex> FindVisibleHexes(Hex origin)
    {
        var visabilityArea = Hex.GetArea(origin, _model.Range).Reverse();
        var visabilityHexes = new List<Hex>() { origin };

        var result = new List<Hex>();
        foreach (var hex in visabilityArea)
        {
            var line = Hex.GetLine(origin, hex).ToList();
            bool blocked = false;

            for (int i = 0; i < line.Count; i++)
            {
                var current = line[i];

                if (blocked)
                    continue;

                if (!visabilityHexes.Contains(current))
                    visabilityHexes.Add(current);

                if (!_hexGrid.GetTiles(current).Any(t => _model.Filter.Contains(t.TileType)))
                    blocked = true;
            }
        }

        return visabilityHexes;
    }

    private void UpdateVisibleTiles(IEnumerable<Hex> oldValue, IEnumerable<Hex> newValue)
    {
        foreach (var hex in oldValue.Except(newValue))
            foreach (var tile in _hexGrid.GetTiles(hex))
                tile.SetInvisible();

        foreach (var hex in newValue.Except(oldValue))
            foreach (var tile in _hexGrid.GetTiles(hex))
                tile.SetVisible();
    }

}
