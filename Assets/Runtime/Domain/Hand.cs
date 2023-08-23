using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Hand
    {
        private readonly int _handSize;
        private readonly Deck _deck;
        public List<Card> Cards { get; }

        public Hand(int handSize, Deck deck, List<Card> cards)
        {
            _handSize = handSize;
            _deck = deck;
            Cards = cards;
        }

        public void PlayCard(Card card)
        {
            Assert.IsTrue(Cards.Contains(card));
            Cards.Remove(card);

            if (Cards.Count == 0)
            {
                for (int i = 0; i < Math.Min(_handSize, _deck.Cards.Count); i++)
                {
                    Cards.Add(DrawCard());
                }
            }
        }

        private Card DrawCard()
        {
            Assert.IsTrue(Cards.Count < _handSize);
            return _deck.DrawCard();
        }
    }
}