namespace Runtime.Domain
{
    public class Connection
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
    }
}