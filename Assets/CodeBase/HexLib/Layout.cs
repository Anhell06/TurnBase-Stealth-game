using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.HexLib
{
    public class Layout : ILayout
    {
        private readonly static Orientation Pointy = new((float)Math.Sqrt(3d), (float)Math.Sqrt(3d) / 2f, 0f, 3f / 2f, (float)Math.Sqrt(3d) / 3f, -1f / 3f, 0f, 2f / 3f, 0.5f);
        private readonly static Orientation Flat = new(3f / 2f, 0f, (float)Math.Sqrt(3d) / 2f, (float)Math.Sqrt(3d), 2f / 3f, 0f, -1f / 3f, (float)Math.Sqrt(3d) / 3f, 0f);

        private readonly Orientation _orientation;
        private readonly Vector2 _hexSize;
        private readonly Vector2 _origin;

        public Layout(OrentationType orentationType, Vector2 hexSize, Vector2 origin)
        {
            _orientation = orentationType == OrentationType.Pointy ? Pointy : Flat;
            _hexSize = hexSize;
            _origin = origin;
        }

        public Vector2 HexToPixel(Hex hex)
        {
            var x = (_orientation.f0 * hex.X + _orientation.f1 * hex.Y) * _hexSize.x;
            var y = (_orientation.f2 * hex.X + _orientation.f3 * hex.Y) * _hexSize.y;
            return new Vector2(x + _origin.x, y + _origin.y);
        }

        public Hex PixelToHex(Vector2 point)
        {
            var pt = new Vector2((point.x - _origin.x) / _hexSize.x, (point.y - _origin.y) / _hexSize.y);
            double q = _orientation.b0 * pt.x + _orientation.b1 * pt.y;
            double r = _orientation.b2 * pt.x + _orientation.b3 * pt.y;
            return Hex.Round(q, r, -q - r);
        }

        public Vector2 HexCornerOffset(int corner)
        {
            double angle = 2.0 * Math.PI * (_orientation.start_angle - corner) / 6.0;
            return new Vector2(_hexSize.x * (float)Math.Cos(angle), _hexSize.y * (float)Math.Sin(angle));
        }

        public List<Vector2> PolygonCorners(Hex hex)
        {
            List<Vector2> corners = new List<Vector2> { };
            Vector2 center = HexToPixel(hex);
            for (int i = 0; i < 6; i++)
            {
                Vector2 offset = HexCornerOffset(i);
                corners.Add(new Vector2(center.x + offset.x, center.y + offset.y));
            }
            return corners;
        }
    }
}