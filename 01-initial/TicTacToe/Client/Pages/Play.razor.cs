using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class Play
    {
        private Board Board { get; set; } = new Board();

        private void Restart()
        {
            this.Board = new Board();
        }

        private void MakeMove(Cell at)
        {
            this.Board = this.Board.Play(at);
        }
    }
}
