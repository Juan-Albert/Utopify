using Runtime.Domain;
using UnityEngine;

namespace Runtime.View
{
    public class ConnectionView : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        private Connection _connection;
        
        public void Setup(Connection connection)
        {
            _connection = connection;
            lineRenderer.SetPositions(new []
            {
                new Vector3(connection.FromSquare.Coordinate.Row + connection.FromSquare.Coordinate.Row * 0.4f,
                    connection.FromSquare.Coordinate.Column + connection.FromSquare.Coordinate.Column * 0.2f,0),
                new Vector3(connection.ToSquare.Coordinate.Row + connection.ToSquare.Coordinate.Row * 0.4f,
                    connection.ToSquare.Coordinate.Column + connection.ToSquare.Coordinate.Column * 0.2f,0)
            });
            Repaint();
        }

        public void Repaint()
        {
            if(_connection.Happiness > 0)
                lineRenderer.material.color = Color.green;
            else if(_connection.Happiness < 0)
                lineRenderer.material.color = Color.red;
            else
                lineRenderer.material.color = Color.gray;
        }
    }
}