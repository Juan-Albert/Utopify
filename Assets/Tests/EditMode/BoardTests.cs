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
    }
}