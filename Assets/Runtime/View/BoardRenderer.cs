using System.Linq;
using Runtime.Domain;
using UnityEngine;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField] ClickableTile emptyTile = null;

    Board board;

    void Start()
    {
        board = Board.Empty;
        Visualize();
    }

    void Visualize()
    {
        for (var i = 0; i < board.AvailableTiles.Count(); i++)
        {
            PlaceTile(board.AvailableTiles.ElementAt(i));
        }
    }

    void PlaceTile((int x, int y) where)
    {
        var tile = Instantiate(emptyTile, transform);
        tile.transform.position = new Vector3(where.x + (where.x * 0.2f), where.y + (where.y * 0.2f), 0);
        tile.Configure(board, where);
    }
}