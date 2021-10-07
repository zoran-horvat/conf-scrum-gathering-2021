using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TicTacToe.Shared
{
    public class Board
    {
        public Board() : this(ImmutableList<Cell>.Empty)
        {
        }

        private Board(ImmutableList<Cell> playedCells)
        {
            this.PlayedCells = playedCells;
            this.ScoreExpression = new Lazy<int>(this.CalculateScore);
        }

        private ImmutableList<Cell> PlayedCells { get; }

        public IEnumerable<Cell> PlayableCells =>
            this.WinningLines
                .Select(win => Enumerable.Empty<Cell>())
                .DefaultIfEmpty(this.EmptyCells)
                .First();

        private IEnumerable<Cell> EmptyCells =>
            Cell.Matrix.Except(this.PlayedCells);

        public IEnumerable<Cell> HomeCells => this.GetCells(0);
        public IEnumerable<Cell> AwayCells => this.GetCells(1);

        public IEnumerable<Line> WinningLines =>
            this.GetWinningLines(0).Concat(this.GetWinningLines(1));

        public int Score => this.ScoreExpression.Value;

        private Lazy<int> ScoreExpression { get; }

        private int CalculateScore() =>
            this.GetWinningLines(0).Select(_ => 1)
                .Concat(this.GetWinningLines(1).Select(_ => -1))
                .DefaultIfEmpty(0)
                .First();

        private IEnumerable<Cell> GetCells(int parity) =>
            this.PlayedCells
                .Select((cell, offset) => (cell, offset))
                .Where(tuple => tuple.offset % 2 == parity)
                .Select(tuple => tuple.cell);

        private IEnumerable<Line> GetWinningLines(int parity) =>
            this.GetCells(parity)
                .SelectMany(cell => cell.Lines)
                .GroupBy(line => line)
                .Where(group => group.Count() == Constants.BoardDimension)
                .Select(group => group.Key);

        public Board Play(Cell at) => new Board(this.PlayedCells.Add(at));
    }
}
