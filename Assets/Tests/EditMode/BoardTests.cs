﻿using System.Collections.Generic;
using NUnit.Framework;
using Runtime.Domain;
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
                new Square(coordinate)
            });
            var boardConnections = new BoardConnections(new List<Connection>(), boardSquares);
            var sut = new Board(1,1, boardSquares, boardConnections);
            var card = new Card(new List<Trait>());
            
            sut.PlayCard(card, coordinate);
            
            Assert.IsTrue(boardSquares.GetSquare(coordinate).HasCard);
        }
        
    }
}