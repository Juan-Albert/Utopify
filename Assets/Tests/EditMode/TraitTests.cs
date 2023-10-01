using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Runtime.Domain;
using static Runtime.Domain.Trait;

namespace Tests.EditMode
{
    public class TraitTests
    {
        [Test]
        public void FriendRelationships()
        {
            var friend = new Trait("friend", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", new[] { "friend" }, Array.Empty<string>());

            sut.RelationWith(friend).Should().Be(Relationship.Friend);
        }

        [Test]
        public void EnemyRelationships()
        {
            var enemy = new Trait("enemy", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Array.Empty<string>(), new[] { "enemy" });

            sut.RelationWith(enemy).Should().Be(Relationship.Enemy);
        }

        [Test]
        public void NeutralRelationships()
        {
            var neutral = new Trait("whatever", Array.Empty<string>(), Array.Empty<string>());
            var sut = new Trait("some", Enumerable.Empty<string>(), Enumerable.Empty<string>());

            sut.RelationWith(neutral).Should().Be(Relationship.Neutral);
        }
    }
}