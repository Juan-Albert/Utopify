using System.Collections.Generic;
using UnityEngine.Assertions;

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

        public bool ConnectionExist(Coordinate from, Coordinate to)
        {
            return ConnectionExist(_connections, from, to);
        }

        public static bool ConnectionExist(List<Connection> connections, Coordinate from, Coordinate to)
        {
            return connections.Exists(x => x.Equals(from, to));
        }

        public Connection GetConnection(Coordinate from, Coordinate to)
        {
            var connection = _connections.Find(x => x.Equals(from, to));
            Assert.IsNotNull(connection);
            return connection;
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
    }
}