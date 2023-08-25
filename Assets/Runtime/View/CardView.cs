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
            switch (card.Traits[0].Type)
            {
                case Trait.TraitType.Good:
                    _meshRenderer.material.color = Color.green;
                    break;
                case Trait.TraitType.Evil:
                    _meshRenderer.material.color = Color.red;
                    break;
                case Trait.TraitType.Happy:
                    _meshRenderer.material.color = Color.yellow;
                    break;
                case Trait.TraitType.Sad:
                    _meshRenderer.material.color = Color.blue;
                    break;
            }
        }
    }
}
