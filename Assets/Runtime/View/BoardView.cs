using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.View
{
    public class BoardView : MonoBehaviour
    {
        [FormerlySerializedAs("squarePrefab")] [SerializeField]
        private SquareView squareViewPrefab;

        private Board _board;
        private List<SquareView> _squareViews;

        private void Awake()
        {
            _squareViews = new List<SquareView>();
        }

        private void BuildBoard()
        {
            foreach (var square in _board.GetSquares())
            {
                var squareView = Instantiate(squareViewPrefab, 
                    new Vector3(square.Coordinate.Row + square.Coordinate.Row * 0.1f, 
                        square.Coordinate.Column + square.Coordinate.Column * 0.1f, 0), Quaternion.identity);
                _squareViews.Add(squareView);
            }
            
            for (int i = -_board.Columns/2; i <= _board.Columns/2; i++)
            {
                for (int j = -_board.Rows/2; j <= _board.Rows/2; j++)
                {
                    var square = Instantiate(squareViewPrefab, new Vector3(i + i * 0.1f, j + j * 0.1f, 0), Quaternion.identity);
                    _squareViews.Add(square);
                }
            }
        }

        public void Setup(Board board)
        {
            _board = board;
            BuildBoard();
        }
    }
}
