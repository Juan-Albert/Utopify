using System;
using System.Collections.Generic;
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

public class FakeHand : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private List<string> friends;
    [SerializeField] private List<string> enemies;
}