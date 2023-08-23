using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Deck
    {
        private Stack<Card> _cards;

        public Deck(IEnumerable<Card> cards)
        {
            _cards = cards as Stack<Card>;
            Shuffle();
        }

        public Card DrawCard()
        {
            Assert.IsTrue(_cards.Count > 0);
            return _cards.Pop();
        }

        public void AddCard(Card card)
        {
            Assert.IsNotNull(card);
            _cards.Push(card);
            Shuffle();
        }

        public void ShuffleDeck(IEnumerable<Card> otherDeck)
        {
            foreach (var card in otherDeck)
            {
                AddCard(card);
            }
        }
        
        private void Shuffle() 
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var shuffledDeck = _cards.Select(x => new { Number = random.Next(), Card = x })
                .OrderBy(x => x.Number)
                .Select(x => x.Card);
            _cards = shuffledDeck as Stack<Card>;
        }
        
    }
}