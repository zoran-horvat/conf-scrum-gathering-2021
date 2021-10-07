using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    internal class PlayCenter : IAutomatedPlayer
    {
        public PlayCenter(IAutomatedPlayer otherPlayer)
        {
            this.OtherPlayer = otherPlayer;
        }

        public string Name => "Computer";

        private IAutomatedPlayer OtherPlayer { get; }

        public Board TryPlay(Board board) =>
            board.PlayableCells
                .Where(cell => cell.Equals(Constants.Center))
                .Select(board.Play)
                .Concat(this.OtherPlayerMove(board))
                .First();

        private IEnumerable<Board> OtherPlayerMove(Board board)
        {
            yield return this.OtherPlayer.TryPlay(board);
        }
    }
}