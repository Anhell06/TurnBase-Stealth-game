using CodeBase.HexLib;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : SerializedMonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    public Hex Coordinates { get; private set; }

    [ReadOnly]
    [SerializeField]
    private TileData _tileData;

    public void Init(TileData tileData, Hex coordinates, int spriteRendererSorting = 0)
    {
        gameObject.name = tileData.name;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = spriteRendererSorting;
        spriteRenderer.sprite = tileData.Image;
        _tileData = tileData;
        Coordinates = coordinates;
    }
}