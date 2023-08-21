namespace Runtime.Domain
{
    public class Board
    {
        public int Columns { get; }
        public int Rows { get; }

        private BoardSquares _boardSquares;
        private BoardConnections _boardConnections;

        public Board(int columns, int rows, BoardSquares boardSquares, BoardConnections boardConnections)
        {
            Columns = columns;
            Rows = rows;
            
            _boardSquares = boardSquares;
            _boardConnections = boardConnections;

        }
    }
}