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

        public void UpdateConnections(Coordinate coordinate)
        {
            CheckSurroundingsForNewConnections(coordinate);
        }

        private void CheckSurroundingsForNewConnections(Coordinate coordinate)
        {
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row + 1, coordinate.Column));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row - 1, coordinate.Column));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row, coordinate.Column + 1));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row, coordinate.Column - 1));
        }

        private void CreateConnectionIfNoExist(Coordinate from, Coordinate to)
        {
            if(!ConnectionExist(from, to))
                _connections.Add(new Connection(_boardSquares.GetSquare(from), _boardSquares.GetSquare(to)));
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