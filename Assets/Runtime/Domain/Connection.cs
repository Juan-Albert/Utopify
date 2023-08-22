using System;

namespace Runtime.Domain
{
    public class Connection : IEquatable<Connection>
    {
        public Square FromSquare { get; }
        public Square ToSquare { get; }

        private int _happiness;

        public Connection(Square fromSquare, Square toSquare)
        {
            FromSquare = fromSquare;
            ToSquare = toSquare;

            _happiness = 0;
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
            return HashCode.Combine(_happiness, FromSquare, ToSquare);
        }

        public void UpdateHappiness()
        {
            _happiness = FromSquare.Compare(ToSquare);
        }
    }
}