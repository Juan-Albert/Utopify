using System;
using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
using UnityEngine;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace Tests.EditMode
{
    public class BoardTests
    {
        private void Initialize(out Coordinate coordinate, out Board.Squares boardSquares, out Board.Connections boardConnections,
            out Board sut, out Card card)
        {
            coordinate = new Coordinate(0, 0);
            boardSquares = new Board.Squares(new List<Square>()
            {
                new (coordinate)
            });
            boardConnections = new Board.Connections(new List<Connection>(), boardSquares);
            sut = new Board(boardSquares, boardConnections);
            card = new Card(new List<Trait>{new ("Good")});
        }

        [Test]
        public void WhenCardPlayed_SquareContainCard()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.GetSquare(coordinate).HasCard);
        }

        [Test]
        public void WhenCardPlayed_NeighbourSquaresCreated()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(1,0)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(-1,0)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(0,1)));
            Assert.IsTrue(boardSquares.SquareExist(new Coordinate(0,-1)));
        }

        [Test]
        public void WhenCardPlayed_NeighboursAreConnected()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(-1,0)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,1)));
            Assert.IsTrue(boardConnections.ConnectionExist(coordinate, new Coordinate(0,-1)));
        }

        [Test]
        public void WhenCalculateBoardHappiness_ReturnCorrectValue()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            card = new Card(new List<Trait>{new ("Good", new []{"Good"}, Array.Empty<string>())});
            
            sut.PlayCard(card, coordinate);
            sut.PlayCard(card, new Coordinate(coordinate.Row + 1, coordinate.Column));
            sut.PlayCard(card, new Coordinate(coordinate.Row - 1, coordinate.Column));
            var result = sut.GetBoardHappiness();
            
            Assert.AreEqual(2, result);
        }
    }
}