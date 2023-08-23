using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class Deck
    {
        public Stack<Card> Cards { get; private set; }

        public Deck(IEnumerable<Card> cards)
        {
            Cards = new Stack<Card>(cards);
            Shuffle();
        }

        public Card DrawCard()
        {
            Assert.IsTrue(Cards.Count > 0);
            return Cards.Pop();
        }

        public void AddCard(Card card)
        {
            Assert.IsNotNull(card);
            Cards.Push(card);
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
            if (Cards.Count > 1)
            {
                var random = new Random((int)DateTime.Now.Ticks);
                var shuffledDeck = Cards.Select(x => new { Number = random.Next(), Card = x })
                    .OrderBy(x => x.Number)
                    .Select(x => x.Card);
                Cards = shuffledDeck as Stack<Card>;
            }
        }
        
    }
}