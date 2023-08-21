using System.Collections.Generic;

namespace Runtime.Domain
{
    public class Board
    {
        public int Columns { get; }
        public int Rows { get; }

        private List<Square> _squares;

        public List<Square> Squares => _squares;

        public Board(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;

            _squares = new List<Square>();
            BuildBoard();
        }

        private void BuildBoard()
        {
            _squares.Clear();
            for (int i = - Columns/2; i <= Columns/2; i++)
            {
                for (int j = -Rows/2; j <= Rows/2; j++)
                {
                    var square = new Square(new Coordinate(i,j));
                    _squares.Add(square);
                }
            }
        }
    }
}