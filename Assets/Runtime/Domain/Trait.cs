using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public record Trait
    {
        public enum Relationship
        {
            Neutral,
            Friend,
            Enemy
        }

        readonly string id;
        string[] friendsIds;
        string[] enemiesIds;

        public Trait(string id, IEnumerable<string> friends, IEnumerable<string> enemies)
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
            return Relationship.Neutral;
        }
    }
}