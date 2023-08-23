using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class BoardTests
    {
        [Test]
        public void WhenCardPlayed_SquareContainCard()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new BoardSquares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>
            {
                new (Trait.TraitType.Good,
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()))
            });
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.GetSquare(coordinate).HasCard);
        }

        [Test]
        public void WhenCardPlayed_NeighbourSquaresCreated()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new BoardSquares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{
                new (Trait.TraitType.Good,
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()))
            });
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(1,0)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(-1,0)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(0,1)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(0,-1)));
        }
        
        [Test]
        public void WhenCardPlayed_NeighboursAreConnected()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new BoardSquares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{
                new (Trait.TraitType.Good,
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>()))
            });
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(-1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,1)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,-1)));
        }

        [Test]
        public void WhenCardPlaced_ConcernedConnectionsUpdateHappiness()
        {
            var fromCoordinate = new Coordinate(0, 0);
            var toCoordinate = new Coordinate(1, 0);
            var boardSquares = new BoardSquares(new List<Square>()
            {
                new (fromCoordinate),
                new (toCoordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var traitComparer = new TraitComparer(
                new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>
                {
                    { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparer.TraitComparerResult.Positive }
                });
            var trait = new Trait(Trait.TraitType.Good, traitComparer);
            var card = new Card(new List<Trait>
            {
                trait
            });
            
            sut.PlayCard(card, fromCoordinate);
            sut.PlayCard(card, toCoordinate);
            
            Assert.AreEqual(boardConnections.GetConnection(fromCoordinate, toCoordinate).Happiness, 2);
            
        }

        [Test]
        public void WhenCalculateBoardHappiness_ReturnCorrectValue()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new BoardSquares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{
                new (Trait.TraitType.Good,
                    new TraitComparer(
                        new Dictionary<(Trait.TraitType, Trait.TraitType), TraitComparer.TraitComparerResult>
                        {
                            { (Trait.TraitType.Good, Trait.TraitType.Good), TraitComparer.TraitComparerResult.Positive }
                        }))
            });
            
            sut.PlayCard(card, coordinate);
            sut.PlayCard(card, new Coordinate(coordinate.Row + 1, coordinate.Column));
            sut.PlayCard(card, new Coordinate(coordinate.Row - 1, coordinate.Column));
            var result = sut.GetBoardHappiness();
            
            Assert.AreEqual(4, result);
        }
    }
}