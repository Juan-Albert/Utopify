using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;

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
            
            boardSquares.GetSquare(coordinate).HasCard.Should().BeTrue();
        }

        [Test]
        public void WhenCardPlayed_NeighbourSquaresCreated()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            
            sut.PlayCard(card, coordinate);
            
            foreach (var neighbour in coordinate.Neighbours())
            {
                boardSquares.SquareExist(neighbour).Should().BeTrue();
            }
        }

        [Test]
        public void WhenCardPlayed_NeighboursAreConnected()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            
            sut.PlayCard(card, coordinate);
            
            foreach (var neighbour in coordinate.Neighbours())
            {
                boardConnections.ConnectionExist(coordinate, neighbour).Should().BeTrue();
            }
        }

        [Test]
        public void WhenCalculateBoardHappiness_ReturnCorrectValue()
        {
            Initialize(out var coordinate, out var boardSquares, out var boardConnections,out var sut, out var card);
            card = new Card(new List<Trait>{new ("Good", new []{"Good"}, Array.Empty<string>())});
            
            sut.PlayCard(card, coordinate);
            sut.PlayCard(card, new Coordinate(coordinate.Row + 1, coordinate.Column));
            sut.PlayCard(card, new Coordinate(coordinate.Row - 1, coordinate.Column));
            
            sut.GetBoardHappiness().Should().Be(2);
        }
    }
}