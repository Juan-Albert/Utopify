using System;
using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.View
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField]
        private SquareView squareViewPrefab;
        [SerializeField]
        private ConnectionView connectionViewPrefab;

        private Board _board;
        private List<SquareView> _squareViews;
        private List<ConnectionView> _connectionViews;

        private void Awake()
        {
            _squareViews = new List<SquareView>();
            _connectionViews = new List<ConnectionView>();
        }

        public void Setup(Board board)
        {
            _board = board;
            BuildBoard();
        }

        private void BuildBoard()
        {
            foreach (var square in _board.AllSquares)
            {
                var squareView = Instantiate(squareViewPrefab, 
                    new Vector3(square.Coordinate.Row + square.Coordinate.Row * 0.4f, 
                        square.Coordinate.Column + square.Coordinate.Column * 0.2f, 0), Quaternion.identity);

                squareView.transform.parent = transform;
                squareView.Setup(square);
                _squareViews.Add(squareView);
            }

            foreach (var connection in _board.GetConnections())
            {
                var rowMiddlePoint =
                    (float)(connection.FromSquare.Coordinate.Row + connection.ToSquare.Coordinate.Row) / 2;
                var columnMiddlePoint =
                    (float)(connection.FromSquare.Coordinate.Column + connection.ToSquare.Coordinate.Column) / 2;
                var connectionView = Instantiate(connectionViewPrefab,
                    new Vector3(rowMiddlePoint + rowMiddlePoint * 0.4f, 
                        columnMiddlePoint + columnMiddlePoint * 0.2f,
                        0), Quaternion.identity);
                connectionView.transform.parent = transform;
                connectionView.Setup(connection);
                _connectionViews.Add(connectionView);
            }
            
        }

        public void UpdateConnections()
        {
            foreach (var connectionView in _connectionViews)
            {       
                connectionView.Repaint();
            }
        }
    }
}
