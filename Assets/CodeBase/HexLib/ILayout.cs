using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.HexLib
{
    public interface ILayout
    {
        Vector2 HexCornerOffset(int corner);
        Vector2 HexToPixel(Hex hex);
        Hex PixelToHex(Vector2 point);
        List<Vector2> PolygonCorners(Hex hex);
    }
}