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
            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { NeutralOfSome }))
                .Should().Be(0);

            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { FriendOfSome }))
                .Should().BeGreaterThan(0);

            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { EnemyOfSome }))
                .Should().BeLessThan(0);
        }

        [Test]
        public void PreviewHappiness_MultiTraitedCards()
        {
            using var _ = new AssertionScope();
            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { NeutralOfSome, Neutral2OfSome }))
                .Should().Be(0);

            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { FriendOfSome, Friend2OfSome }))
                .Should().BeGreaterThan
                (
                    new Card(new[] { Some })
                        .PreviewHappinessWith(new Card(new[] { FriendOfSome, }))
                );

            new Card(new[] { Some })
                .PreviewHappinessWith(new Card(new[] { EnemyOfSome, Enemy2OfSome }))
                .Should().BeLessThan
                (
                    new Card(new[] { Some })
                        .PreviewHappinessWith(new Card(new[] { EnemyOfSome, }))
                );
            
            new Card(new[]{Some})
                .PreviewHappinessWith(new Card(new[] { EnemyOfSome, Friend2OfSome}))
                .Should().Be
                (
                    new Card(new[] { Some })
                        .PreviewHappinessWith(new Card(new[] { NeutralOfSome, }))
                );
        }
    }
}