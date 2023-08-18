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
    public class GameController : MonoBehaviour
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
            var boardConfig = Resources.Load<BoardConfig>($"BoardConfig");
            Assert.IsNotNull(boardConfig);
            var board = new Board(5,5);

            CardConfig[] cardConfigs = Resources.LoadAll<CardConfig>($"Cards/");
            Assert.IsTrue(cardConfigs.Length > 0);

            TraitComparer traitComparer = new TraitComparer();
            List<Trait> traits = new List<Trait>();
            traits.Add(new Trait(Trait.TraitType.Good, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Evil, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Happy, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Sad, traitComparer));
            
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardConfigs.Length; i++)
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