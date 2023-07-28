using System.Collections.Generic;
using Runtime.Domain;
using Runtime.Scriptable;
using UnityEngine;

namespace Runtime.View
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField]
        private Square squarePrefab;

        private Board _board;
        private List<Square> _squares;

        private void Awake()
        {
            _squares = new List<Square>();
        }

        private void BuildBoard()
        {
            for (int i = -_board.Columns/2; i <= _board.Columns/2; i++)
            {
                for (int j = -_board.Rows/2; j <= _board.Rows/2; j++)
                {
                    var square = Instantiate(squarePrefab, new Vector3(i + i * 0.1f, j + j * 0.1f, 0), Quaternion.identity);
                    _squares.Add(square);
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
