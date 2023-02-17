namespace CodeBase.HexLib
{
    public struct DoubledCoord
    {
        public readonly int Col;
        public readonly int Row;

        public DoubledCoord(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public static DoubledCoord QdoubledFromCube(Hex h)
        {
            int col = h.X;
            int row = 2 * h.Y + h.X;
            return new DoubledCoord(col, row);
        }

        public static DoubledCoord RdoubledFromCube(Hex h)
        {
            int col = 2 * h.X + h.Y;
            int row = h.Y;
            return new DoubledCoord(col, row);
        }

        public Hex QdoubledToCube()
        {
            int q = Col;
            int r = (Row - Col) / 2;
            int s = -q - r;
            return new Hex(q, r, s);
        }

        public Hex RdoubledToCube()
        {
            int q = (Col - Row) / 2;
            int r = Row;
            int s = -q - r;
            return new Hex(q, r, s);
        }
    }
}