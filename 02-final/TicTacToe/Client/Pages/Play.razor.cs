using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using TicTacToe.Shared;

namespace TicTacToe.Client.Pages
{
    public partial class Play
    {
        private Game Game { get; set; } = new Game();
        private Board Board => this.Game.Board;

        private void Restart()
        {
            this.Game = this.Game.Restart();
        }

        private void MakeMove(Cell at)
        {
            this.Game = this.Game.Play(at);
        }
    }
}
