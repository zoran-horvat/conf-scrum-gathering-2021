using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared
{
    public record Cell(int Row, int Column) : IComparable<Cell>
    {
        public static IEnumerable<Cell> Matrix =>
            Enumerable
                .Range(0, Constants.BoardSize)
                .Select(offset => new Cell(offset / Constants.BoardDimension, offset % Constants.BoardDimension));

        public IEnumerable<Line> Lines
        {
            get
            {
                yield return Line.Row(this.Row);
                yield return Line.Column(this.Column);

                if (this.Row == this.Column) yield return Line.Diagonal();
                if (this.Row + this.Column + 1 == Constants.BoardDimension) yield return Line.Antidiagonal();
            }
        }

        public int CompareTo(Cell other) =>
            this.Row == other.Row ? this.Column.CompareTo(other.Column)
                : this.Row.CompareTo(other.Row);
    }
}
