using System;
using Runtime.Domain;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    BoardRenderer board;
    (int x, int y) whereIs;

    void OnMouseDown()
    {
        board.PlaceAt(whereIs, Card.WithTraits(new Trait("friend", Array.Empty<string>(), Array.Empty<string>())));
    }

    public void Configure(BoardRenderer board, (int x, int y) whereIs)
    {
        this.board = board;
        this.whereIs = whereIs;
    }
}