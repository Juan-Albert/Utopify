using System;
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
            var friend = new Trait("friend");
            var sut = new Trait("some", new []{"friend"});
            
            sut.RelationWith(friend).Should().Be(Relationship.Friend);
        } 
        
        [Test]
        public void EnemyRelationships()
        {
            var enemy = new Trait("enemy");
            var sut = new Trait("some", Array.Empty<string>(), new []{"enemy"});
            
            sut.RelationWith(enemy).Should().Be(Relationship.Enemy);
        }
    }
}