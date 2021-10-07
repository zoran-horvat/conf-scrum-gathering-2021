namespace TicTacToe.Shared
{
    public class Game
    {
        public Game()
            : this(new Board(), new HumanPlayer(), 
                   new PlayCenter(new MinimaxPlayer()))
        {
        }

        private Game(Board board, IPlayer home, IPlayer away)
        {
            this.Board = board;
            this.Home = home;
            this.Away = away;
        }

        public Board Board { get; }
        public IPlayer Home { get; }
        public IPlayer Away { get; }

        public Game Restart() =>
            new Game(new Board(), this.Away, this.Home).PlayAutomated();

        private Game PlayAutomated() =>
            new Game(this.MakeAutomatedMove(this.Board), this.Home, this.Away);

        public Game Play(Cell at) =>
            new Game(this.MakeFullMove(at), this.Home, this.Away);

        private Board MakeFullMove(Cell at) =>
            this.MakeAutomatedMove(this.MakeInteractiveMove(at, this.Board));

        private Board MakeInteractiveMove(Cell at, Board board) =>
            this.CurrentPlayer<IInteractivePlayer>(board)?.Accept(at, board) ?? board;

        private Board MakeAutomatedMove(Board board) => 
            this.CurrentPlayer<IAutomatedPlayer>(board)?.TryPlay(board) ?? board;

        private TPlayer? CurrentPlayer<TPlayer>(Board board) where TPlayer : class, IPlayer =>
            (board.MovesCount % 2 == 0 ? this.Home : this.Away) as TPlayer;
    }
}