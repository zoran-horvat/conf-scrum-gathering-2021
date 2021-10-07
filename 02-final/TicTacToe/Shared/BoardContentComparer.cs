using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    internal class BoardContentComparer : IEqualityComparer<Board>
    {
        public bool Equals(Board x, Board y) =>
            this.SymbolPositions(x)
                .SequenceEqual(this.SymbolPositions(y));

        public int GetHashCode(Board obj) =>
            this.SymbolPositions(obj)
                .Select(symbol => symbol.GetHashCode())
                .DefaultIfEmpty(0)
                .Aggregate(HashCode.Combine);

        private IEnumerable<Cell> SymbolPositions(Board board) =>
            board.HomeCells.OrderBy(x => x).Concat(board.AwayCells.OrderBy(o => o));
    }
}