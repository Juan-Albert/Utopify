using System;
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
    }

    void Update()
    {
        RenderBoard();
    }

    void RenderBoard()
    {
        DeletePreviousBoard();
        GenerateBoardTiles();
    }

    void DeletePreviousBoard()
    {
        foreach (Transform child in transform) 
            Destroy(child.gameObject);
    }

    void GenerateBoardTiles()
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
        tile.Configure(this, where);
    }
    
    public void PlaceAt((int, int) where, Card card) => board = board.PlaceAt(where, card);
}