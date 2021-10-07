namespace TicTacToe.Shared
{
    internal interface IAutomatedPlayer : IPlayer
    {
        Board TryPlay(Board board);
    }
}