using System.Collections.Generic;
using UnityEngine.Assertions;

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

        public List<Square> GetSquares()
        {
            return _boardSquares.Squares;
        }

        public void PlayCard(Card playedCard, Coordinate coordinate)
        {
            Assert.IsTrue(_boardSquares.SquareExist(coordinate));

            _boardSquares.PlayCard(playedCard, coordinate);
        }
    }
}