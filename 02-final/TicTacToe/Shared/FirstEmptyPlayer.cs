using System.Linq;

namespace TicTacToe.Shared
{
    internal class FirstEmptyPlayer : IAutomatedPlayer
    {
        public string Name => "Computer";

        public Board TryPlay(Board board) =>
            board.PlayableCells
                .Select(board.Play)
                .DefaultIfEmpty(board)
                .First();
    }
}