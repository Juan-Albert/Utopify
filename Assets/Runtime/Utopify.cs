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
            
            var traitComparisons = new Dictionary<(Trait.Name, Trait.Name), TraitComparer.Result>
            {
                { (Trait.Name.Good, Trait.Name.Good), TraitComparer.Result.Positive },
                { (Trait.Name.Good, Trait.Name.Evil), TraitComparer.Result.Negative },
                { (Trait.Name.Good, Trait.Name.Happy), TraitComparer.Result.Neutral },
                { (Trait.Name.Good, Trait.Name.Sad), TraitComparer.Result.Neutral },
                { (Trait.Name.Evil, Trait.Name.Evil), TraitComparer.Result.Positive },
                { (Trait.Name.Evil, Trait.Name.Happy), TraitComparer.Result.Negative },
                { (Trait.Name.Evil, Trait.Name.Sad), TraitComparer.Result.Negative },
                { (Trait.Name.Happy, Trait.Name.Happy), TraitComparer.Result.Positive },
                { (Trait.Name.Happy, Trait.Name.Sad), TraitComparer.Result.Negative },
                { (Trait.Name.Sad, Trait.Name.Sad), TraitComparer.Result.Positive }
            };
            var traitComparer = new TraitComparer(traitComparisons);
            
            var traits = new List<Trait>();
            traits.Add(new Trait(Trait.Name.Good, traitComparer));
            traits.Add(new Trait(Trait.Name.Evil, traitComparer));
            traits.Add(new Trait(Trait.Name.Happy, traitComparer));
            traits.Add(new Trait(Trait.Name.Sad, traitComparer));

            var cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                var cardTrait = new List<Trait> { traits[Random.Range(0, traits.Count)] };
                cards.Add(new Card(cardTrait));
            }

            var deck = new Deck(cards);
            var hand = new Hand(2, deck, new List<Card>());
            var player = new Player(hand, board);

            var boardView = Instantiate(boardViewPrefab, Vector3.zero, Quaternion.identity);
            boardView.Setup(board);
            
            var handViewInGame = Instantiate(handViewPrefab, new Vector3(0,-4,0), Quaternion.identity);
            handViewInGame.Setup(hand, cardViewPrefab);
            
            Instantiate(playerViewPrefab,  Vector3.zero, Quaternion.identity).Setup(player, handViewInGame, boardView);
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