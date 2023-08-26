using System;
using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public readonly partial  struct NewTrait : IComparable<NewTrait>
    {
        readonly string id;
        readonly string[] friends;
        readonly string[] enemies;

        public NewTrait(string id) : this(id, Array.Empty<string>(), Array.Empty<string>()) { }
        
        public NewTrait(string id, IEnumerable<string> friends, IEnumerable<string> enemies)
        {
            this.id = id;
            this.friends = friends.ToArray();
            this.enemies = enemies.ToArray();
        }
        
        public int CompareTo(NewTrait other)
        {
            if (friends.Contains(other.id))
                return Relation.Friend;
            if (enemies.Contains(other.id))
                return Relation.Enemy;
            
            if(id == other.id)
                throw new NotSupportedException("Tiene que estar en los amigos metido");
            return Relation.Neutral;
        }
        
        public override bool Equals(object obj) => obj is NewTrait other && Equals(other);
        public bool Equals(NewTrait other) => id == other.id;
        public override int GetHashCode() => id.GetHashCode();
        public static bool operator ==(NewTrait left, NewTrait right) => left.Equals(right);
        public static bool operator !=(NewTrait left, NewTrait right) => !left.Equals(right);
        public static bool operator <(NewTrait left, NewTrait right) => left.CompareTo(right) < 0;
        public static bool operator >(NewTrait left, NewTrait right) => left.CompareTo(right) > 0;
        public static bool operator <=(NewTrait left, NewTrait right) => left.CompareTo(right) <= 0;
        public static bool operator >=(NewTrait left, NewTrait right) => left.CompareTo(right) >= 0;
    }
}