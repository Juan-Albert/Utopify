using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class ConnectionView : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        private Board.Connections _allConnections;
        private Connection _connection;
        
        public void Setup(Connection connection, Board.Connections allConnections)
        {
            _connection = connection;
            _allConnections = allConnections;
            lineRenderer.SetPositions(new []
            {
                new Vector3(connection.From.Row + connection.From.Row * 0.4f,
                    connection.From.Column + connection.From.Column * 0.2f,0),
                new Vector3(connection.To.Row + connection.To.Row * 0.4f,
                    connection.To.Column + connection.To.Column * 0.2f,0)
            });
            
            Repaint();
        }

        public void Repaint()
        {
            lineRenderer.material.color = _allConnections.CalculateHappinessAt(_connection) switch
            {
                > 0 => Color.green,
                < 0 => Color.red,
                _ => Color.gray
            };
        }
    }
}