namespace Runtime.Domain
{
    public class Board
    {
        public int Columns { get; }

        public int Rows { get; }

        public Board(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }
    }
}