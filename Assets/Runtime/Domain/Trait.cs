using System;
using System.Collections.Generic;
using System.Linq;

namespace Runtime.Domain
{
    public readonly partial  struct Trait : IComparable<Trait>
    {
        private readonly string _id;

        public string ID => _id;

        private readonly string[] _friends;
        private readonly string[] _enemies;

        public Trait(string id) : this(id, Array.Empty<string>(), Array.Empty<string>()) { }
        
        public Trait(string id, IEnumerable<string> friends, IEnumerable<string> enemies)
        {
            this._id = id;
            this._friends = friends.ToArray();
            this._enemies = enemies.ToArray();
        }
        
        public int CompareTo(Trait other)
        {
            if (_friends.Contains(other._id))
                return Relation.Friend;
            if (_enemies.Contains(other._id))
                return Relation.Enemy;
            
            return Relation.Neutral;
        }
        
        public override bool Equals(object obj) => obj is Trait other && Equals(other);
        public bool Equals(Trait other) => _id == other._id;
        public override int GetHashCode() => _id.GetHashCode();
        public static bool operator ==(Trait left, Trait right) => left.Equals(right);
        public static bool operator !=(Trait left, Trait right) => !left.Equals(right);
        public static bool operator <(Trait left, Trait right) => left.CompareTo(right) < 0;
        public static bool operator >(Trait left, Trait right) => left.CompareTo(right) > 0;
        public static bool operator <=(Trait left, Trait right) => left.CompareTo(right) <= 0;
        public static bool operator >=(Trait left, Trait right) => left.CompareTo(right) >= 0;
    }
}