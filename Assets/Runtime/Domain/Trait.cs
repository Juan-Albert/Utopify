using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public record Trait
    {
        public enum Relationship
        {
            Neutral = 0,
            Friend = 1,
            Enemy = -1
        }

        readonly string id;
        readonly string[] friendsIds;
        readonly string[] enemiesIds;

        public Trait(string id, IEnumerable<string> friends, IEnumerable<string> enemies)
        {
            if(friends is null || enemies is null)
                throw new System.NotSupportedException();
            
            if(friends.Count() != friends.Distinct().Count())
                throw new System.NotSupportedException();
            if(enemies.Count() != enemies.Distinct().Count())
                throw new System.NotSupportedException();
            
            this.id = id;
            friendsIds = friends.ToArray();
            enemiesIds = enemies.ToArray();
        }

        public Relationship RelationWith(Trait friend)
        {
            if (friendsIds?.Contains(friend.id) ?? false)
                return Relationship.Friend;
            if (enemiesIds?.Contains(friend.id) ?? false)
                return Relationship.Enemy;
            return Relationship.Neutral;
        }
    }
}