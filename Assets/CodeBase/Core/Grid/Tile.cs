using CodeBase.HexLib;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : SerializedMonoBehaviour
{
    public TileType TileType => _tileData.Type;

    [ReadOnly]
    [SerializeField]
    public Hex Coordinates { get; private set; }

    [ReadOnly]
    [SerializeField]
    private TileData _tileData;

    private SpriteRenderer _spriteRenderer;

    public void Init(TileData tileData, Hex coordinates, int spriteRendererSorting = 0)
    {
        gameObject.name = tileData.name;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingOrder = spriteRendererSorting;
        _spriteRenderer.sprite = tileData.Image;
        _tileData = tileData;
        Coordinates = coordinates;
    }

    public void SetVisible()
    {
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = Color.white;
    }

    public void SetInvisible()
    {
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = Color.gray;
    }
}