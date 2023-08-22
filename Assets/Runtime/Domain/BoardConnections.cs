using System.Collections.Generic;

namespace Runtime.Domain
{
    public class BoardConnections
    {
        private readonly List<Connection> _connections;
        private BoardSquares _boardSquares;

        public BoardConnections(List<Connection> connections, BoardSquares boardSquares)
        {
            _connections = connections;
            _boardSquares = boardSquares;
        }
        
        private bool ConnectionExist(Coordinate from, Coordinate to)
        {
            return ConnectionExist(_connections, from, to);
        }
        
        public static bool ConnectionExist(List<Connection> connections, Coordinate from, Coordinate to)
        {
            return connections.Exists(x => (x.FromSquare.Coordinate.Equals(from)
                                            && x.ToSquare.Coordinate.Equals(to))
                                           || (x.FromSquare.Coordinate.Equals(to)
                                               && x.ToSquare.Coordinate.Equals(from)));
        }
        
    }
}