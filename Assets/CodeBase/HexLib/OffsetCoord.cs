namespace CodeBase.HexLib
{
    public struct OffsetCoord
    {
        public readonly int Col;
        public readonly int Row;

        public OffsetCoord(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public static OffsetCoord QoffsetFromCube(Parity parity, Hex h)
        {
            int col = h.X;
            int row = h.Y + ((h.X + (int)parity * (h.X & 1)) / 2);
            return new OffsetCoord(col, row);
        }

        public static Hex QoffsetToCube(Parity parity, OffsetCoord h)
        {
            int q = h.Col;
            int r = h.Row - (h.Col + (int)parity * (h.Col & 1)) / 2;
            int s = -q - r;
            return new Hex(q, r, s);
        }

        public static OffsetCoord RoffsetFromCube(Parity parity, Hex h)
        {
            int col = h.X + ((h.Y + (int)parity * (h.Y & 1)) / 2);
            int row = h.Y;
            return new OffsetCoord(col, row);
        }

        public static Hex RoffsetToCube(Parity parity, OffsetCoord h)
        {
            int q = h.Col - (int)((h.Row + (int)parity * (h.Row & 1)) / 2);
            int r = h.Row;
            int s = -q - r;
            return new Hex(q, r, s);
        }

        public enum Parity
        {
            ODD = -1,
            EVEN = 1
        }

        public override string ToString() => $"Col: {Col}, Row: {Row}";
    }
}