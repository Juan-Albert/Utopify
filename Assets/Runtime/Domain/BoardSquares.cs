using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class BoardSquares
    {
        public List<Square> Squares { get; }

        public BoardSquares(List<Square> squares)
        {
            Squares = squares;
        }
        
        public bool SquareExist(Coordinate coord)
        {
            return Squares.Exists(x => x.Coordinate.Equals(coord));
        }

        public Square GetSquare(Coordinate coord)
        {
            var square = Squares.Find(x => x.Coordinate.Equals(coord));
            Assert.IsNotNull(square);

            return square;
        }

        public void PlayCard(Card playedCard, Coordinate coordinate)
        {
            GetSquare(coordinate).PlayCard(playedCard);
        }
    }
}