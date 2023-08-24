using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class SquareView : MonoBehaviour
    {
        public CardView CardViewInSquare { get; set; }
        public bool HasCard => CardViewInSquare != null;
        
        public Square Square { get; private set; }

        public void Setup(Square square)
        {
            Square = square;
        }

        public void PutCard(CardView cardPlayed)
        {
            CardViewInSquare = cardPlayed;
            cardPlayed.transform.position = transform.position;
        }
    }
}