using System;
using System.Collections.Generic;
using Runtime.Domain;
using Runtime.View;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//TODO Milestones

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
            
            var traits = new List<Trait>
            {
                new ("Good", new[] { "Good" }, new[] { "Evil" }),
                new ("Evil", new[] { "Evil" }, new[] { "Good", "Happy", "Sad" }),
                new ("Happy", new []{ "Good", "Happy",}, new []{"Evil", "Sad"}),
                new ("Sad", new []{ "Happy", "Good"}, new []{"Sad"})
            };

            var cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                var cardTrait = new List<Trait> { traits[Random.Range(0, traits.Count)] };
                cards.Add(new Card(cardTrait));
            }

            var deck = new Deck(cards);
            var hand = new Hand(2, deck, new List<Card>());
            var player = new Player(hand, board, new List<Milestone>()
            {
                new (2, deck, cards),
                new (5, deck, cards),
                new (10, deck, cards)
                
            });

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
            var boardSquares = new Board.Squares(squares);

            var connections = new List<Connection>();
            foreach (var square in boardSquares)
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
            var boardConnections = new Board.Connections(connections, boardSquares);
            
            return new Board(boardSquares, boardConnections);

            void CheckForValidConnectionCreation(Square fromSquare, Coordinate toCoordinate)
            {
                if (boardSquares.SquareExist(toCoordinate) &&
                    !Board.Connections.ConnectionExist(connections, fromSquare.Coordinate,toCoordinate))
                {
                    var connection = new Connection(fromSquare.Coordinate, toCoordinate);
                    connections.Add(connection);
                }
            }
        }
    }
}