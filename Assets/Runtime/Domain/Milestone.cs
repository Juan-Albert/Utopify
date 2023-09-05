using System.Collections.Generic;

namespace Runtime.Domain
{
    public class Milestone
    {
        private readonly Deck _deck;
        private readonly List<Card> _cards;

        public bool Completed { get; private set; }

        public int Goal { get; }

        public Milestone(int goal, Deck deck, List<Card> cards)
        {
            Goal = goal;
            _deck = deck;
            _cards = cards;
            Completed = false;
        }

        public void Complete()
        {
            Completed = true;
            _deck.ShuffleDeck(_cards);
        }
    }
}