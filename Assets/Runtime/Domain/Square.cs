using System;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Square
    {
        public Coordinate Coordinate { get; }

        private Card _card;

        public Card CardInSquare
        {
            get
            {
                Assert.IsNotNull(_card);
                return _card;
            }
        }

        public bool HasCard => _card != null;
        
        public Square(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void PlayCard(Card playedCard)
        {
            Assert.IsFalse(HasCard);

            _card = playedCard;
        }

        public int Compare(Square otherSquare)
        {
            return HasCard ? (otherSquare.HasCard ? _card.CompareTraits(otherSquare.CardInSquare) : 0) : 0;
        }
    }
}