using System;
using System.Collections.Generic;

namespace CodeBase.HexLib
{
    public partial struct Hex
    {
        public static Hex Zero = new(0, 0, 0); 
        public enum Direction
        {
            Up,
            Down,
            LeftUp,
            RigthUp,
            LeftDown,
            RightDown
        }

        public static Hex operator *(Hex hex, int k)
            => new(hex.X * k, hex.Y * k, hex.Z * k);

        public static Hex operator +(Hex a, Hex b)
            => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Hex operator -(Hex a, Hex b)
            => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static bool operator ==(Hex a, Hex b)
            => a.Equals(b);

        public static bool operator !=(Hex a, Hex b)
            => !a.Equals(b);

        public static Dictionary<Direction, Hex> Directions = new()
        {
            { Direction.Up, new Hex(1, 0, -1) },
            { Direction.LeftUp, new Hex(1, -1, 0) },
            { Direction.LeftDown, new Hex(0, -1, 1) },
            { Direction.Down, new Hex(-1, 0, 1) },
            { Direction.RightDown, new Hex(-1, 1, 0) },
            { Direction.RigthUp, new Hex(0, 1, -1) }
        };


        public static Hex Neighbor(Hex hex, Direction direction)
            => hex + Directions[direction];

        public static Hex DiagonalNeighbor(Hex hex, Direction a, Direction b)
            => hex + Directions[a] + Directions[b];

        public static int Distance(Hex a, Hex b)
            => (Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z)) / 2;

        public static IReadOnlyList<Hex> GetRing(Hex center, int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("The radius should be > 0");

            var ring = new List<Hex>(radius * 6);

            var hexInRing = center + Directions[Direction.RightDown] * radius;

            foreach (var dir in Directions.Keys)
            {
                for (int i = 0; i < radius; i++)
                {
                    ring.Add(hexInRing);
                    hexInRing = Neighbor(hexInRing, dir);
                }
            }

            return ring;
        }

        public static ICollection<Hex> GetArea(Hex center, int radius)
        {
            if (radius <= 0)
                throw new ArgumentException("The radius should be > 0");

            var area = new List<Hex>() { center };

            for (int i = 1; i <= radius; i++)
            {
                area.AddRange(GetRing(center, i));
            }

            return area;
        }

        public static ICollection<Hex> GetLine(Hex a, Hex b)
        {
            var distance = Distance(a, b);
            var results = new List<Hex>();
            var step = 1.0 / Math.Max(distance, 1);

            for (int i = 0; i <= distance; i++)
            {
                results.Add(Hex.Round(
                (a.X + 1e-06) * (1.0 - (step * i)) + (b.X + 1e-06) * (step * i),
                (a.Y + 1e-06) * (1.0 - (step * i)) + (b.Y + 1e-06) * (step * i),
                (a.Z - 2e-06) * (1.0 - (step * i)) + (b.Z - 2e-06) * (step * i)
                ));
            }

            return results;
        }

        internal static Hex Round(double x, double y, double z)
        {
            int qi = (int)(Math.Round((double)x));
            int ri = (int)(Math.Round((double)y));
            int si = (int)(Math.Round((double)z));

            double q_diff = Math.Abs(qi - x);
            double r_diff = Math.Abs(ri - y);
            double s_diff = Math.Abs(si - z);

            if (q_diff > r_diff && q_diff > s_diff)
                qi = -ri - si;
            else if (r_diff > s_diff)
                ri = -qi - si;
            else
                si = -qi - ri;

            return new Hex(qi, ri, si);
        }
    }
}