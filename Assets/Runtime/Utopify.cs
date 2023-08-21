using System;
using System.Collections.Generic;
using Runtime.Domain;
using Runtime.Scriptable;
using Runtime.View;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class Utopify : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardView;
        [SerializeField]
        private CardView cardView;
        
        private void Awake()
        {
            InitGame();
        }

        private void InitGame()
        {
            var board = new Board(5,5);

            Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult> traitComparisons = new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>
            {
                { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparer.TraitComparerResult.Positive },
                { (Trait.TraitType.Good, Trait.TraitType.Evil), TraitComparer.TraitComparerResult.Negative },
                { (Trait.TraitType.Good, Trait.TraitType.Happy), TraitComparer.TraitComparerResult.Neutral },
                { (Trait.TraitType.Good, Trait.TraitType.Sad), TraitComparer.TraitComparerResult.Neutral },
                { (Trait.TraitType.Evil, Trait.TraitType.Evil), TraitComparer.TraitComparerResult.Positive },
                { (Trait.TraitType.Evil, Trait.TraitType.Happy), TraitComparer.TraitComparerResult.Negative },
                { (Trait.TraitType.Evil, Trait.TraitType.Sad), TraitComparer.TraitComparerResult.Negative },
                { (Trait.TraitType.Happy, Trait.TraitType.Happy), TraitComparer.TraitComparerResult.Positive },
                { (Trait.TraitType.Happy, Trait.TraitType.Sad), TraitComparer.TraitComparerResult.Negative },
                { (Trait.TraitType.Sad, Trait.TraitType.Sad), TraitComparer.TraitComparerResult.Positive }
            };
            TraitComparer traitComparer = new TraitComparer(traitComparisons);
            
            List<Trait> traits = new List<Trait>();
            traits.Add(new Trait(Trait.TraitType.Good, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Evil, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Happy, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Sad, traitComparer));
            
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                List<Trait> cardTrait = new List<Trait>();
                cardTrait.Add(traits[Random.Range(0, traits.Count)]);
                cards.Add(new Card(cardTrait));
            }

            Instantiate(boardView, Vector3.zero, Quaternion.identity).Setup(board);

            foreach (Card card in cards)
            {
                Instantiate(cardView, Vector3.zero, Quaternion.identity).Setup(card);
            }
        }
    }
}