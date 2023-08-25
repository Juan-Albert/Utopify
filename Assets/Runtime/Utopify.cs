using System;
using System.Collections.Generic;
using Runtime.Domain;
using Runtime.Scriptable;
using Runtime.View;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class Utopify : MonoBehaviour
    {
        [SerializeField]
        private BoardView boardViewPrefab;
        [SerializeField]
        private PlayerView playerViewPrefab;
        [SerializeField]
        private HandView handViewPrefab;
        [SerializeField]
        private CardView cardViewPrefab;
        
        private void Awake()
        {
            InitGame();
        }

        private void InitGame()
        {
            var board = BuildBoard();
            
            var traitComparisons = new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>
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
            var traitComparer = new TraitComparer(traitComparisons);
            
            var traits = new List<Trait>();
            traits.Add(new Trait(Trait.TraitType.Good, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Evil, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Happy, traitComparer));
            traits.Add(new Trait(Trait.TraitType.Sad, traitComparer));

            var cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                var cardTrait = new List<Trait> { traits[Random.Range(0, traits.Count)] };
                cards.Add(new Card(cardTrait));
            }

            var deck = new Deck(cards);
            var hand = new Hand(2, deck, new List<Card>());
            var player = new Player(hand, board);

            Instantiate(boardViewPrefab, Vector3.zero, Quaternion.identity).Setup(board);
            
            var handViewInGame = Instantiate(handViewPrefab, new Vector3(0,-4,0), Quaternion.identity);
            handViewInGame.Setup(hand, cardViewPrefab);
            
            Instantiate(playerViewPrefab,  Vector3.zero, Quaternion.identity).Setup(player, handViewInGame);
        }

        private Board BuildBoard()
        {
            var columns = 5;
            var rows = 5;

            var squares = new List<Square>();
            for (int i = - columns/2; i <= columns/2; i++)
            {
                for (int j = -rows/2; j <= rows/2; j++)
                {
                    var square = new Square(new Coordinate(i,j));
                    squares.Add(square);
                }
            }
            var boardSquares = new BoardSquares(squares);

            var connections = new List<Connection>();
            foreach (var square in boardSquares.Squares)
            {
                CheckForValidConnectionCreation(square,
                    new Coordinate(square.Coordinate.Row + 1,
                        square.Coordinate.Column));
                CheckForValidConnectionCreation(square,
                    new Coordinate(square.Coordinate.Row - 1,
                        square.Coordinate.Column));
                CheckForValidConnectionCreation(square,
                    new Coordinate(square.Coordinate.Row,
                        square.Coordinate.Column + 1));
                CheckForValidConnectionCreation(square,
                    new Coordinate(square.Coordinate.Row,
                        square.Coordinate.Column - 1));
            }
            var boardConnections = new BoardConnections(connections, boardSquares);
            
            return new Board(boardSquares, boardConnections);

            void CheckForValidConnectionCreation(Square fromSquare, Coordinate toCoordinate)
            {
                if (boardSquares.SquareExist(toCoordinate) &&
                    !BoardConnections.ConnectionExist(connections, fromSquare.Coordinate,toCoordinate))
                {
                    var connection = new Connection(fromSquare, boardSquares.GetSquare(toCoordinate));
                    connections.Add(connection);
                }
            }
        }
    }
}