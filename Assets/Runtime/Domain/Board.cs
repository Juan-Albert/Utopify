using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        public Squares AllSquares { get; }
        public Connections AllConnections { get; }

        public int Rows
        {
            get
            {
                var larger = AllSquares.Max(x => x.Coordinate.Row);
                var smaller = AllSquares.Min(x => x.Coordinate.Row);
                return larger - smaller;
            }
        }

        public int Columns
        {
            get
            {
                var larger = AllSquares.Max(x => x.Coordinate.Column);
                var smaller = AllSquares.Min(x => x.Coordinate.Column);
                return larger - smaller;
            }
        }

        public Board(Squares AllSquares, Connections connections)
        {
            this.AllSquares = AllSquares;
            this.AllConnections = connections;
        }


        public int GetBoardHappiness()
        {
            return AllConnections.Sum(connection => AllConnections.CalculateHappinessAt(connection));
        }

        public void PlayCard(Card playedCard, Coordinate coordinate)
        {
            Assert.IsTrue(AllSquares.SquareExist(coordinate));
            AllSquares.PlayCard(playedCard, coordinate);
            AllConnections.CheckSurroundingsForNewConnections(coordinate);
        }
    }
}