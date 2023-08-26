using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        private readonly Squares squares;
        private readonly Connections connections;

        public int Rows
        {
            get
            {
                var larger = squares.REFACTORING.Max(x => x.Coordinate.Row);
                var smaller = squares.REFACTORING.Min(x => x.Coordinate.Row);
                return larger - smaller;
            }
        }

        public int Columns
        {
            get
            {
                var larger = squares.REFACTORING.Max(x => x.Coordinate.Column);
                var smaller = squares.REFACTORING.Min(x => x.Coordinate.Column);
                return larger - smaller;
            }
        }

        public Board(Squares squares, Connections connections)
        {
            this.squares = squares;
            this.connections = connections;
        }

        public List<Square> GetSquares()
        {
            return squares.REFACTORING;
        }

        public List<Connection> GetConnections()
        {
            return connections.refactoring;
        }

        public int GetBoardHappiness()
        {
            return connections.BoardHappiness;
        }

        public void PlayCard(Card playedCard, Coordinate coordinate)
        {
            Assert.IsTrue(squares.SquareExist(coordinate));
            squares.PlayCard(playedCard, coordinate);
            connections.CardPlayedAt(coordinate);
        }
    }
}