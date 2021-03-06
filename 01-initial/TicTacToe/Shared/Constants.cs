namespace TicTacToe.Shared
{
    internal static class Constants
    {
        public static int BoardDimension => 3;
        public static int LastCellOffset => BoardDimension - 1;
        public static int BoardSize => BoardDimension * BoardDimension;
        public static Cell Center => new Cell(BoardDimension / 2, BoardDimension / 2);
    }
}
