using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        public class Connections : IEnumerable<Connection>
        {
            private readonly Squares squares;
            List<Connection> _connections { get; }

            public int BoardHappiness => _connections.Sum(connection => connection.Happiness);

            public Connections(List<Connection> connections, Squares squares)
            {
                _connections = connections;
                this.squares = squares;
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
                Assert.IsTrue(ConnectionExist(from, to));
                return _connections.Find(x => x.Equals(from, to));
            }

            public void CardPlayedAt(Coordinate coordinate)
            {
                CheckSurroundingsForNewConnections(coordinate);
                UpdateConnectionsAt(coordinate);
            }

            private void CheckSurroundingsForNewConnections(Coordinate coordinate)
            {
                foreach(var neighbour in coordinate.Neighbours())
                {
                    CreateConnectionIfNoExist(coordinate, neighbour);
                }
            }

            private void UpdateConnectionsAt(Coordinate coordinate)
            {
                foreach(var neighbour in coordinate.Neighbours())
                {
                    GetConnection(coordinate, neighbour).UpdateHappiness();
                }
            }

            private void CreateConnectionIfNoExist(Coordinate from, Coordinate to)
            {
                if(!ConnectionExist(from, to))
                    _connections.Add(new Connection(squares.GetSquare(from), squares.GetSquare(to)));
            }

            public IEnumerator<Connection> GetEnumerator()
            {
                return _connections.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}