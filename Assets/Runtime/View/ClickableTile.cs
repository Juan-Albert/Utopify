using System;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    BoardRenderer board;
    (int x, int y) whereIs;

    void OnMouseDown()
    {
        board.PlaceAt(whereIs, FindObjectOfType<FakeHand>().NextCard);
    }

    public void Configure(BoardRenderer board, (int x, int y) whereIs)
    {
        this.board = board;
        this.whereIs = whereIs;
    }
}