using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        public class Connections
        {
            private readonly Squares squares;
            public List<Connection> refactoring { get; }

            public int BoardHappiness => refactoring.Sum(connection => connection.Happiness);

            public Connections(List<Connection> connections, Squares squares)
            {
                refactoring = connections;
                this.squares = squares;
            }

            public bool ConnectionExist(Coordinate from, Coordinate to)
            {
                return ConnectionExist(refactoring, from, to);
            }

            public static bool ConnectionExist(List<Connection> connections, Coordinate from, Coordinate to)
            {
                return connections.Exists(x => x.Equals(from, to));
            }

            public Connection GetConnection(Coordinate from, Coordinate to)
            {
                var connection = refactoring.Find(x => x.Equals(from, to));
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
                    refactoring.Add(new Connection(squares.GetSquare(from), squares.GetSquare(to)));
            }
        }
    }
}