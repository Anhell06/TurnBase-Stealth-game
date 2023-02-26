using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Core.Grid
{
    [CreateAssetMenu(fileName = "Tile", menuName = "Grid/Tile")]
    internal class TileData : ScriptableObject
    {
        [HorizontalGroup("Tile", 75)]
        [PreviewField(75)]
        [HideLabel]
        public Sprite Image;

        [VerticalGroup("Tile/Data")]
        [LabelWidth(75)]
        public TileType Type;
    }
}
