namespace TicTacToe.Shared
{
    internal interface IInteractivePlayer : IPlayer
    {
        Board Accept(Cell move, Board board);
    }
}