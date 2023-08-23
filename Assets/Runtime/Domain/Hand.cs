using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Hand
    {
        private readonly int _handSize;
        private readonly List<Card> _cards;
        private readonly Deck _deck;

        public Hand(int handSize, List<Card> cards, Deck deck)
        {
            _handSize = handSize;
            _cards = cards;
            _deck = deck;
        }

        public void PlayCard(Card card)
        {
            Assert.IsTrue(_cards.Contains(card));
            _cards.Remove(card);

            if (_cards.Count == 0)
            {
                for (int i = 0; i < Math.Min(_handSize, _deck.Cards.Count); i++)
                {
                    _cards.Add(DrawCard());
                }
            }
        }

        private Card DrawCard()
        {
            return _deck.DrawCard();
        }
    }
}