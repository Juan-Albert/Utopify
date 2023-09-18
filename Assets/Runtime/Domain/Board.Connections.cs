using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Runtime.Domain
{
    public partial class Board
    {
        //todo borrar connections y calcular el mapa como conjunto de coordenadas
        public class Connections : IEnumerable<Connection>
        {
            private readonly Squares _squares;
            List<Connection> _connections { get; }

            public Connections(List<Connection> connections, Squares squares)
            {
                _connections = connections;
                _squares = squares;
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
            
            public int CalculateHappinessAt(Coordinate from, Coordinate to)
            {
                return _squares.GetSquare(from).Compare(_squares.GetSquare(to));
            }

            public int CalculateHappinessAt(Connection connection)
            {
                return CalculateHappinessAt(connection.From, connection.To);
            }

            public void CheckSurroundingsForNewConnections(Coordinate coordinate)
            {
                foreach(var neighbour in coordinate.Neighbours())
                {
                    CreateConnectionIfNoExist(coordinate, neighbour);
                }
            }

            private void CreateConnectionIfNoExist(Coordinate from, Coordinate to)
            {
                if(!ConnectionExist(from, to))
                    _connections.Add(new Connection(from, to));
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