using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Runtime.Domain;
using static Tests.EditMode.TestFixture;

namespace Tests.EditMode
{
    public class CardTests
    {
        [Test]
        public void PreviewHappiness_SingleTraitedCards()
        {
            using var _ = new AssertionScope();
            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(NeutralOfSome))
                .Should().Be(0);

            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(FriendOfSome))
                .Should().BeGreaterThan(0);

            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(EnemyOfSome))
                .Should().BeLessThan(0);
        }

        [Test]
        public void PreviewHappiness_MultiTraitedCards()
        {
            using var _ = new AssertionScope();
            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(NeutralOfSome, Neutral2OfSome))
                .Should().Be(0);

            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(FriendOfSome, Friend2OfSome))
                .Should().BeGreaterThan
                (
                    Card.WithTraits(Some)
                        .PreviewHappinessWith(Card.WithTraits(FriendOfSome))
                );

            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(EnemyOfSome, Enemy2OfSome))
                .Should().BeLessThan
                (
                    Card.WithTraits(Some)
                        .PreviewHappinessWith(Card.WithTraits(EnemyOfSome))
                );

            Card.WithTraits(Some)
                .PreviewHappinessWith(Card.WithTraits(EnemyOfSome, Friend2OfSome))
                .Should().Be
                (
                    Card.WithTraits(Some)
                        .PreviewHappinessWith(Card.WithTraits(NeutralOfSome))
                );
        }

        [Test]
        public void PreviewRelationship()
        {
            Card.WithTraits(Some)
                .PreviewjbasjdfWith(Card.WithTraits(NeutralOfSome))
                .Should().Be(Card.jbasjdf.Neutral);
        }
    }
}