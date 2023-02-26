using CodeBase.Core.Grid;
using CodeBase.HexLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Character.Visability
{
    internal class CharacterVisabilityController : ICharacterVisabilityController
    {
        private readonly CharacterVisabilityView _view;
        private readonly CharacterVisabilityModel _model;
        private readonly ILayout _layout;
        private readonly IHexGrid _hexGrid;

        internal CharacterVisabilityController(CharacterVisabilityView view, CharacterVisabilityModel model, ILayout layout, IHexGrid hexGrid)
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
            _hexGrid.MarkHexesInvisible(this, oldValue);

            _hexGrid.MarkHexesVisible(this, newValue);
        }
    }
}
