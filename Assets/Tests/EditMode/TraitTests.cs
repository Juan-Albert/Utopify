using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;

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

    public record Trait
    {
        readonly string id;
        string[] friendsIds;
        string[] enemiesIds;

        public Trait(string id, IEnumerable<string> friends = null, IEnumerable<string> enemies = null)
        {
            this.id = id;
            friendsIds = friends?.ToArray();
            enemiesIds = enemies?.ToArray();
        }

        public Relationship RelationWith(Trait friend)
        {
            if (friendsIds?.Contains(friend.id) ?? false)
                return Relationship.Friend;
            if (enemiesIds?.Contains(friend.id) ?? false)
                return Relationship.Enemy;
            return Relationship.Friend;
        }
    }

    public enum Relationship { Friend,
        Enemy
    }
}