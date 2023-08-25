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

        private Board _board;
        private List<SquareView> _squareViews;

        private void Awake()
        {
            _squareViews = new List<SquareView>();
        }

        public void Setup(Board board)
        {
            _board = board;
            BuildBoard();
        }

        private void BuildBoard()
        {
            foreach (var square in _board.GetSquares())
            {
                var squareView = Instantiate(squareViewPrefab, 
                    new Vector3(square.Coordinate.Row + square.Coordinate.Row * 0.4f, 
                        square.Coordinate.Column + square.Coordinate.Column * 0.2f, 0), Quaternion.identity);

                squareView.transform.parent = transform;
                squareView.Setup(square);
                _squareViews.Add(squareView);
            }
        }
    }
}
