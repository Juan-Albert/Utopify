using System;

namespace Runtime.Domain
{
    public class Connection : IEquatable<Connection>
    {
        private Square FromSquare { get; }
        private Square ToSquare { get; }

        public int Happiness { get; private set; }

        public Connection(Square fromSquare, Square toSquare)
        {
            FromSquare = fromSquare;
            ToSquare = toSquare;

            Happiness = 0;
        }

        public bool Equals(Coordinate from, Coordinate to)
        {
            return (FromSquare.Coordinate.Equals(from)&& ToSquare.Coordinate.Equals(to))
                || (FromSquare.Coordinate.Equals(to)&& ToSquare.Coordinate.Equals(from));
        }

        public bool Equals(Connection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.FromSquare.Coordinate, other.ToSquare.Coordinate);
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
            return HashCode.Combine(FromSquare.Coordinate.GetHashCode(), ToSquare.Coordinate.GetHashCode());
        }

        public void UpdateHappiness()
        {
            Happiness = FromSquare.Compare(ToSquare);
        }
    }
}