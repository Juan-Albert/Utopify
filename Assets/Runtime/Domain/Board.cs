using Runtime.Scriptable;

namespace Runtime.Domain
{
    public class Board
    {
        public int Columns { get; }

        public int Rows { get; }

        public Board(BoardConfig boardConfig)
        {
            Columns = boardConfig.columns;
            Rows = boardConfig.rows;
        }
    }
}