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
    }
}