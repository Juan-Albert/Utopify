using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public class BoardConnections
    {
        private readonly BoardSquares _boardSquares;

        public int BoardHappiness => Connections.Sum(connection => connection.Happiness);
        public List<Connection> Connections { get; }

        public BoardConnections(List<Connection> connections, BoardSquares boardSquares)
        {
            Connections = connections;
            _boardSquares = boardSquares;
        }
        
        public bool ConnectionExist(Coordinate from, Coordinate to)
        {
            return ConnectionExist(Connections, from, to);
        }

        public static bool ConnectionExist(List<Connection> connections, Coordinate from, Coordinate to)
        {
            return connections.Exists(x => x.Equals(from, to));
        }

        public Connection GetConnection(Coordinate from, Coordinate to)
        {
            var connection = Connections.Find(x => x.Equals(from, to));
            Assert.IsNotNull(connection);
            return connection;
        }

        public void CardPlayedAt(Coordinate coordinate)
        {
            CheckSurroundingsForNewConnections(coordinate);
            UpdateConnectionsAt(coordinate);
        }

        private void CheckSurroundingsForNewConnections(Coordinate coordinate)
        {
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row + 1, coordinate.Column));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row - 1, coordinate.Column));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row, coordinate.Column + 1));
            CreateConnectionIfNoExist(coordinate, new Coordinate(coordinate.Row, coordinate.Column - 1));
        }

        private void UpdateConnectionsAt(Coordinate coordinate)
        {
            GetConnection(coordinate, new Coordinate(coordinate.Row + 1, coordinate.Column)).UpdateHappiness();
            GetConnection(coordinate, new Coordinate(coordinate.Row - 1, coordinate.Column)).UpdateHappiness();
            GetConnection(coordinate, new Coordinate(coordinate.Row, coordinate.Column + 1)).UpdateHappiness();
            GetConnection(coordinate, new Coordinate(coordinate.Row, coordinate.Column - 1)).UpdateHappiness();
        }

        private void CreateConnectionIfNoExist(Coordinate from, Coordinate to)
        {
            if(!ConnectionExist(from, to))
                Connections.Add(new Connection(_boardSquares.GetSquare(from), _boardSquares.GetSquare(to)));
        }
    }
}