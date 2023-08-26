using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        public class Squares
        {
            public List<Square> REFACTORING { get; }

            public Squares(List<Square> squares)
            {
                REFACTORING = squares;
            }

            public bool SquareExist(Coordinate coord)
            {
                return REFACTORING.Exists(x => x.Coordinate.Equals(coord));
            }

            public Square GetSquare(Coordinate coord)
            {
                var square = REFACTORING.Find(x => x.Coordinate.Equals(coord));
                Assert.IsNotNull(square);

                return square;
            }

            public void PlayCard(Card playedCard, Coordinate coordinate)
            {
                GetSquare(coordinate).PlayCard(playedCard);
                CheckSurroundingsForNewSquares(coordinate);
            }

            private void CheckSurroundingsForNewSquares(Coordinate coordinate)
            {
                CreateSquareIfNoExist(new Coordinate(coordinate.Row + 1, coordinate.Column));
                CreateSquareIfNoExist(new Coordinate(coordinate.Row - 1, coordinate.Column));
                CreateSquareIfNoExist(new Coordinate(coordinate.Row, coordinate.Column + 1));
                CreateSquareIfNoExist(new Coordinate(coordinate.Row, coordinate.Column - 1));
            }

            private void CreateSquareIfNoExist(Coordinate coordinate)
            {
                if(!SquareExist(coordinate))
                    REFACTORING.Add(new Square(coordinate));
            }
        }
    }
}