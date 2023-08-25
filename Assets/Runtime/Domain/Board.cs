using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Board
    {
        private readonly BoardSquares _boardSquares;

        private BoardConnections _boardConnections;

        public int Rows
        {
            get
            {
                var larger = _boardSquares.Squares.Max(x => x.Coordinate.Row);
                var smaller = _boardSquares.Squares.Min(x => x.Coordinate.Row);
                return larger - smaller;
            }
        }

        public int Columns
        {
            get
            {
                var larger = _boardSquares.Squares.Max(x => x.Coordinate.Column);
                var smaller = _boardSquares.Squares.Min(x => x.Coordinate.Column);
                return larger - smaller;
            }
        }

        public Board(BoardSquares boardSquares, BoardConnections boardConnections)
        {
            _boardSquares = boardSquares;
            _boardConnections = boardConnections;
        }

        public List<Square> GetSquares()
        {
            return _boardSquares.Squares;
        }

        public List<Connection> GetConnections()
        {
            return _boardConnections.Connections;
        }

        public int GetBoardHappiness()
        {
            return _boardConnections.BoardHappiness;
        }

        public void PlayCard(Card playedCard, Coordinate coordinate)
        {
            Assert.IsTrue(_boardSquares.SquareExist(coordinate));
            _boardSquares.PlayCard(playedCard, coordinate);
            _boardConnections.CardPlayedAt(coordinate);
        }
    }
}