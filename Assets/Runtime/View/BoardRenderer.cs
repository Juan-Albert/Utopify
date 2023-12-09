using System.Linq;
using Runtime.Domain;
using UnityEngine;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField] GameObject emptyTile = null;

    Board board;

    void Start()
    {
        board = Board.Empty;
        Visualize();
    }

    void Visualize()
    {
        for (int i = 0; i < board.AvailableTiles.Count(); i++)
        {
            Instantiate(emptyTile, transform).transform.position =
                new Vector3(board.AvailableTiles.ElementAt(i).x + (board.AvailableTiles.ElementAt(i).x * 0.2f),
                    board.AvailableTiles.ElementAt(i).y + (board.AvailableTiles.ElementAt(i).y * 0.2f), 0);
        }
    }
}