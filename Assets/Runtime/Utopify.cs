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
            var board = BuildBoard();
            
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

            var player = new Player(new Hand(1, new Deck(cards), new List<Card>()), board);

            Instantiate(boardView, Vector3.zero, Quaternion.identity).Setup(board);

            foreach (Card card in cards)
            {
                Instantiate(cardView, Vector3.zero, Quaternion.identity).Setup(card);
            }
        }

        private Board BuildBoard()
        {
            var columns = 5;
            var rows = 5;

            List<Square> squares = new List<Square>();
            for (int i = - columns/2; i <= columns/2; i++)
            {
                for (int j = -rows/2; j <= rows/2; j++)
                {
                    var square = new Square(new Coordinate(i,j));
                    squares.Add(square);
                }
            }
            var boardSquares = new BoardSquares(squares);

            List<Connection> connections = new List<Connection>();
            for (int i = 0; i < boardSquares.Squares.Count; i++)
            {
                CheckForValidConnectionCreation(boardSquares.Squares[i],
                    new Coordinate(boardSquares.Squares[i].Coordinate.Row + 1,
                        boardSquares.Squares[i].Coordinate.Column));
                CheckForValidConnectionCreation(boardSquares.Squares[i],
                    new Coordinate(boardSquares.Squares[i].Coordinate.Row - 1,
                        boardSquares.Squares[i].Coordinate.Column));
                CheckForValidConnectionCreation(boardSquares.Squares[i],
                    new Coordinate(boardSquares.Squares[i].Coordinate.Row,
                        boardSquares.Squares[i].Coordinate.Column + 1));
                CheckForValidConnectionCreation(boardSquares.Squares[i],
                    new Coordinate(boardSquares.Squares[i].Coordinate.Row,
                        boardSquares.Squares[i].Coordinate.Column - 1));
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