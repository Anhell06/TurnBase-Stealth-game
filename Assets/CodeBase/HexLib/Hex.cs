using System;

namespace CodeBase.HexLib
{
    public partial struct Hex
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public Hex(int x, int y, int z)
        {
            if (x + y + z != 0)
                throw new ArgumentException("x + y + z must be 0");

            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
            => $"x: {X}, y: {Y}, z:{Z}";

        public override bool Equals(object obj)
        {
            if (obj is not Hex)
                return false;

            var cell = (Hex)obj;
            return X == cell.X &&
                   Y == cell.Y &&
                   Z == cell.Z;
        }

        public override int GetHashCode()
            => HashCode.Combine(X, Y, Z);
    }
}