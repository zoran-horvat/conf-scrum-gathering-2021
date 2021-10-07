namespace TicTacToe.Shared
{
    public record Line(Cell From, Cell To)
    {
        public static Line Row(int offset) =>
            new Line(new Cell(offset, 0), new Cell(offset, Constants.LastCellOffset));

        public static Line Column(int offset) =>
            new Line(new Cell(0, offset), new Cell(Constants.LastCellOffset, offset));

        public static Line Diagonal() =>
            new Line(new Cell(0, 0), new Cell(Constants.LastCellOffset, Constants.LastCellOffset));

        public static Line Antidiagonal() =>
            new Line(new Cell(0, Constants.LastCellOffset), new Cell(Constants.LastCellOffset, 0));
    }
}
