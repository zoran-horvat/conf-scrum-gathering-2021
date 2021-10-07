using System.Linq;

namespace TicTacToe.Shared
{
    internal class HumanPlayer : IInteractivePlayer
    {
        public string Name => "Human";

        public Board Accept(Cell move, Board board) =>
            board.PlayableCells
                .Where(cell => cell.Equals(move))
                .Select(board.Play)
                .DefaultIfEmpty(board)
                .First();
    }
}