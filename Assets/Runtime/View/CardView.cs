using System;
using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] 
        private MeshRenderer _meshRenderer;
        public Card Card { get; private set; }

        public void Setup(Card card)
        {
            Card = card;
            switch (card.Traits[0].ID)
            {
                case "Good":
                    _meshRenderer.material.color = Color.green;
                    break;
                case "Evil":
                    _meshRenderer.material.color = Color.red;
                    break;
                case "Happy":
                    _meshRenderer.material.color = Color.yellow;
                    break;
                case "Sad":
                    _meshRenderer.material.color = Color.blue;
                    break;
            }
        }
    }
}
