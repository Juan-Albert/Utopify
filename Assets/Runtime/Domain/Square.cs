using System;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Square
    {
        public Coordinate Coordinate { get; }

        private Card _card;

        private bool HasCard => _card != null;
        
        public Square(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public void PlayCard(Card playedCard)
        {
            Assert.IsFalse(HasCard);

            _card = playedCard;
        }
    }
}