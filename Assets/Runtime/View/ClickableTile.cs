using System;
using Runtime.Domain;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    Board board;
    (int x, int y) whereIs;

    void OnMouseDown()
    {
        board.PlaceAt(whereIs, Card.WithTraits(new Trait("random", Array.Empty<string>(), Array.Empty<string>())));
    }

    public void Configure(Board board, (int x, int y) whereIs)
    {
        this.board = board;
        this.whereIs = whereIs;
    }
}