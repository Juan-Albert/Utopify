using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Runtime.Domain;
using static Tests.EditMode.TestFixture;

namespace Tests.EditMode
{
    public class BoardTests
    {
        [Test]
        public void PutACard()
        {
            Board.Empty.PlaceAt((0, 0), Card.WithTraits(Some))
                .ExistsAt((0, 0))
                .Should().BeTrue();
        }

        [Test]
        public void CardNotExist_AtEmptyTile()
        {
            Board.Empty
                .ExistsAt((0, 0))
                .Should().BeFalse();
        }

        [Test]
        public void HappinessIsZeroByDefault()
        {
            Board.Empty.Happiness.Should().Be(0);
        }

        [Test]
        public void HappinessIsZero_WhenOneCardPlaced()
        {
            Board.Empty.PlaceAt((0, 0), Card.WithTraits(Some))
                .Happiness
                .Should().Be(0);
        }

        [Test]
        public void HappinessIsZero_WhenNoNeighbours()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .PlaceAt((5465, 4224), Card.WithTraits(Some))
                .Happiness
                .Should().Be(0);
        }

        [Test]
        public void Happiness_IsSumOfIndividualHappiness()
        {
            var card = Card.WithTraits(Some);
            Board.Empty
                .PlaceAt((0, 0), card)
                .PlaceAt((1, 0), card)
                .Happiness
                .Should().Be(0);


            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .PlaceAt((1, 0), Card.WithTraits(FriendOfSome))
                .Happiness
                .Should().Be(Card.WithTraits(Some)
                    .PreviewHappinessWith(Card.WithTraits(FriendOfSome)));

            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(FriendOfItself))
                .PlaceAt((1, 0), Card.WithTraits(FriendOfItself))
                .PlaceAt((0, 1), Card.WithTraits(FriendOfItself))
                .PlaceAt((1, 1), Card.WithTraits(FriendOfItself))
                .Happiness
                .Should().Be(Card.WithTraits(FriendOfItself)
                    .PreviewHappinessWith(Card.WithTraits(FriendOfItself)) * 4);
        }

        [Test]
        public void NeighboursCoords()
        {
            (0, 0).AreNeighbours((0, 1)).Should().BeTrue();
            (0, 0).AreNeighbours((0, 43)).Should().BeFalse();
        }

        [Test]
        public void Happiness_Between_TwoNeighbourTiles()
        {
            Board.Empty.PlaceAt((0, 0), Card.WithTraits(Some)).PlaceAt((0, 1), Card.WithTraits(Some))
                .HappinessBetween((0, 0), (0, 1))
                .Should().Be(0);

            Board.Empty.PlaceAt((0, 0), Card.WithTraits(Some)).PlaceAt((0, 1), Card.WithTraits(FriendOfSome))
                .HappinessBetween((0, 0), (0, 1))
                .Should().BeGreaterThan(0);
        }

        [Test]
        public void HappinessInATile_BasedInTheirNeighbours()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .PlaceAt((0, 1), Card.WithTraits(FriendOfSome))
                .PlaceAt((0, -1), Card.WithTraits(FriendOfSome))
                .PlaceAt((1, 0), Card.WithTraits(FriendOfSome))
                .PlaceAt((-1, 0), Card.WithTraits(FriendOfSome))
                .HappinessOf((0, 0))
                .Should().Be(Card.WithTraits(Some)
                    .PreviewHappinessWith(Card.WithTraits(FriendOfSome)) * 4);
        }

        [Test]
        public void HappinessInATile_WithTwoNeighbours()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .PlaceAt((0, 1), Card.WithTraits(FriendOfSome))
                .PlaceAt((0, -1), Card.WithTraits(FriendOfSome))
                .HappinessOf((0, 0))
                .Should().Be(Card.WithTraits(Some)
                    .PreviewHappinessWith(Card.WithTraits(FriendOfSome)) * 2);
        }

        [Test]
        public void ExcludeNeighbours()
        {
            new List<(int, int)> { (0, 0), (0, 1) }.WithoutNeighbours().Should().HaveCount(1);
        }

        [Test]
        public void AvailableTiles_AreNine_ByDefault()
        {
            Board.Empty.AvailableTiles.Should().HaveCount(9);
        }
        
        [Test]
        public void ExcludeOccupiedTiles_FromAvailables()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .AvailableTiles.Should().NotContain((0,0));
        }

        [Test]
        public void IncludeNeighboursTiles_AsAvailable()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .AvailableTiles.Should().Contain((-1,0))
                .And.Contain((0,-1));
        }

        [Test]
        public void AvailableTiles_ContainsNoDuplication()
        {
            Board.Empty
                .PlaceAt((0, 0), Card.WithTraits(Some))
                .AvailableTiles.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void IgnoreNeighbourTile_IfOccupied()
        {
            Board.Empty.PlaceAt((0, 0), Card.WithTraits(Some)).PlaceAt((0, 1), Card.WithTraits(Some)).AvailableTiles
                .Should().NotContain((0, 0));
        }
    }
}