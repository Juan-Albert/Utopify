using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public record Trait
    {
        public enum Affinity
        {
            Neutral = 0,
            Friend = 1,
            Enemy = -1
        }

        public readonly string id;
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

        public Affinity AffinityWith(Trait friend)
        {
            if (friendsIds?.Contains(friend.id) ?? false)
                return Affinity.Friend;
            if (enemiesIds?.Contains(friend.id) ?? false)
                return Affinity.Enemy;
            return Affinity.Neutral;
        }
    }
}