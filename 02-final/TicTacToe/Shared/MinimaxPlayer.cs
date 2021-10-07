using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    internal class MinimaxPlayer : IAutomatedPlayer
    {
        public string Name => "Computer";

        private Random Rng { get; } = new Random();
        private Dictionary<Board, (List<Board> winners, int score)> BoardToWinner { get; } =
            new(new BoardContentComparer());

        public Board TryPlay(Board board) =>
            this.SelectRandomWinner(this.Minimax(board).winners);

        private Board SelectRandomWinner(List<Board> candidates) =>
            candidates[this.Rng.Next(candidates.Count)];

        private (List<Board> winners, int score) Minimax(Board board)
        {
            if (this.BoardToWinner.TryGetValue(board, out (List<Board>, int) winner)) return winner;
            winner = this.FullMinimax(board);
            this.BoardToWinner[board] = winner;
            return winner;
        }

        private (List<Board> winners, int score) FullMinimax(Board board) =>
            board.PlayableCells
                .Select(board.Play)
                .Select(next => (board: next, score: this.Minimax(next).score))
                .DefaultIfEmpty((board, score: board.Score))
                .GroupBy(pair => pair.score)
                .OrderByDescending(group => group.Key * this.ComparisonSign(board))
                .Select(group => (group.Select(pair => pair.board).ToList(), group.Key))
                .First();

        private int ComparisonSign(Board board) =>
            1 - 2 * (board.MovesCount % 2);
    }
}