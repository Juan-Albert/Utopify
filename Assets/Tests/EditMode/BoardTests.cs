using System;
using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    //TODO Hacer un Builder
    public class BoardTests
    {
        [Test]
        public void WhenCardPlayed_SquareContainCard()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new Board.Squares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new Board.Connections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{new ("Good")});
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.GetSquare(coordinate).HasCard);
        }

        [Test]
        public void WhenCardPlayed_NeighbourSquaresCreated()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new Board.Squares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new Board.Connections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{new ("Good")});
            
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
            var boardSquares = new Board.Squares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new Board.Connections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{new ("Good")});
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(-1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,1)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,-1)));
        }

        [Test]
        public void WhenCalculateBoardHappiness_ReturnCorrectValue()
        {
            var coordinate = new Coordinate(0, 0);
            var boardSquares = new Board.Squares(new List<Square>()
            {
                new (coordinate)
            });
            var boardConnections = new Board.Connections(new List<Connection>(), boardSquares);
            var sut = new Board(boardSquares, boardConnections);
            var card = new Card(new List<Trait>{new ("Good", new []{"Good"}, Array.Empty<string>())});
            
            sut.PlayCard(card, coordinate);
            sut.PlayCard(card, new Coordinate(coordinate.Row + 1, coordinate.Column));
            sut.PlayCard(card, new Coordinate(coordinate.Row - 1, coordinate.Column));
            var result = sut.GetBoardHappiness();
            
            Assert.AreEqual(2, result);
        }
    }
}