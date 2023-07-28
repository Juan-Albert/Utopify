using System;
using System.Collections.Generic;
using Runtime.Domain;
using Runtime.Scriptable;
using Runtime.View;
using UnityEngine;
using UnityEngine.Assertions;

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
            var board = new Board(boardConfig);

            CardConfig[] cardConfigs = Resources.LoadAll<CardConfig>($"Cards/");
            Assert.IsTrue(cardConfigs.Length > 0);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < cardConfigs.Length; i++)
            {
                cards.Add(new Card(cardConfigs[i]));
            }

            Instantiate(boardView, Vector3.zero, Quaternion.identity).Setup(board);

            foreach (Card card in cards)
            {
                Instantiate(cardView, Vector3.zero, Quaternion.identity).Setup(card);
            }
        }
    }
}