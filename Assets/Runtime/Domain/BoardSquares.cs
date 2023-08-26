using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        public class Squares : IEnumerable<Square>
        {
            List<Square> _squares { get; }

            public Squares(List<Square> squares)
            {
                _squares = squares;
            }

            public bool SquareExist(Coordinate coord)
            {
                return _squares.Exists(x => x.Coordinate.Equals(coord));
            }

            public Square GetSquare(Coordinate coord)
            {
                var square = _squares.Find(x => x.Coordinate.Equals(coord));
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
                    _squares.Add(new Square(coordinate));
            }
            
            public IEnumerator<Square> GetEnumerator()
            {
                return _squares.GetEnumerator();
            }
            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}