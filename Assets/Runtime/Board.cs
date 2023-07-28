using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class Board : MonoBehaviour
    {
        [SerializeField]
        private Square squarePrefab;
        private List<Square> _squares;

        private void Awake()
        {
            _squares = new List<Square>();
            BuildBoard();
        }

        private void BuildBoard()
        {
            int size = 5;
            for (int i = -size/2; i <= size/2; i++)
            {
                for (int j = -size/2; j <= size/2; j++)
                {
                    var square = Instantiate(squarePrefab, new Vector3(i + i * 0.1f, j + j * 0.1f, 0), Quaternion.identity);
                    _squares.Add(square);
                }
            }
        }
    }
}
