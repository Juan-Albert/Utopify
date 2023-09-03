using System;

namespace Runtime.Domain
{
    public class Connection : IEquatable<Connection>
    {
        public Coordinate From { get; }
        public Coordinate To { get; }
        
        //TODO autocalculate happiness on method & refactor to erase connection class
        public Connection(Coordinate from, Coordinate to)
        {
            From = from;
            To = to;
        }

        public bool Equals(Coordinate from, Coordinate to)
        {
            return (From.Equals(from)&& To.Equals(to))
                || (From.Equals(to)&& To.Equals(from));
        }

        public bool Equals(Connection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.From, other.To);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Connection)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From.GetHashCode(), To.GetHashCode());
        }
    }
}