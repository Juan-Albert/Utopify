using System.Collections.Generic;
using System.Linq;
using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class HandView : MonoBehaviour
    {
        private CardView _cardViewPrefab;
        private Hand _hand;

        private List<CardView> Cards { get; set; }

        public void Setup(Hand hand, CardView cardPrefab)
        {
            _hand = hand;
            _cardViewPrefab = cardPrefab;
            Cards = new List<CardView>();
            DrawCards();
        }
        
        public void ReturnCard(CardView cardToPlay)
        {
            var pos = Cards.IndexOf(cardToPlay) - Cards.Count / 2; 
            cardToPlay.transform.position = transform.position + new Vector3(pos, 0, 0);
        }

        public void DropCard(CardView cardToPlay)
        {
            Cards.Remove(cardToPlay);
            DrawCards();
        }

        private void RelocateCards()
        {
            foreach (var cardView in Cards)
            {
                var pos = Cards.IndexOf(cardView) - Cards.Count / 2; 
                cardView.transform.position = transform.position + new Vector3(pos, 0, 0);
            }
        }

        private void DrawCards()
        {
            var unrepeatedCards = _hand.Cards.Except(Cards.Select(x => x.Card));

            foreach (var unrepeatedCard in unrepeatedCards)
            {
                var cardDrawed = Instantiate(_cardViewPrefab, transform);
                cardDrawed.Setup(unrepeatedCard);
                Cards.Add(cardDrawed);
            }
            RelocateCards();
        }
    }
}