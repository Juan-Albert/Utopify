using System;
using System.Linq;
using Runtime.Domain;
using UnityEngine;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField] ClickableTile emptyTile = null;
    [SerializeField] GameObject cardPrefab = null;
    [SerializeField] Connection connectionPrefab = null;

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
        GenerateCards();
        GenerateConnections();
    }

    void GenerateConnections()
    {
        for (var i = 0; i < board.Connections.Count(); i++)
        {
            PlaceConnection(board.Connections.ElementAt(i));
        }
    }

    void PlaceConnection(((int x, int y), (int x, int y)) connection)
    {
        var tile = Instantiate(connectionPrefab, transform);
        tile.Configure(connection);
    }

    void GenerateCards()
    {
        for (var i = 0; i < board.OccupiedTiles.Count(); i++)
        {
            PlaceCardAt(board.OccupiedTiles.ElementAt(i));
        }
    }

    void PlaceCardAt((int x, int y) elementAt)
    {
        var card = Instantiate(cardPrefab, transform);
        card.transform.position =
            new Vector3(elementAt.x + (elementAt.x * 0.2f), elementAt.y + (elementAt.y * 0.2f), 0);
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