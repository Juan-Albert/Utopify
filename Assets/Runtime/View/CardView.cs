using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class CardView : MonoBehaviour
    {
        public Card Card { get; private set; }

        public void Setup(Card card)
        {
            Card = card;
        }
    }
}
