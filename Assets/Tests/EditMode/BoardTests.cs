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
        public void RequestCardAtEmptyTile()
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
        public void HappinessIsZeroWhenOneCardPlaced()
        {
            Board.Empty.PlaceAt((0,0), Card.WithTraits(Some))
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
                .Should().Be(0);
        }
        
        [Test]
        public void NeighboursCoords()
        {
            (0, 0).IsNeighbourOf((0, 1)).Should().BeTrue();
            (0, 0).IsNeighbourOf((0, 43)).Should().BeFalse();
        }
    }
}