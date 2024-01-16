using System;
using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;

public struct asfasfas
{
    public string id;
    public Color howLooksLike;

    public asfasfas(string id, Color howLooksLike)
    {
        this.id = id;
        this.howLooksLike = howLooksLike;
    }
}

public class Hardcodedadsfsad : MonoBehaviour
{
    [SerializeField] List<asfasfas> fsafsa = new List<asfasfas> { new asfasfas("friend", Color.red),new asfasfas("enemyOfFriend", Color.red) };
}

public class ClickableTile : MonoBehaviour
{
    BoardRenderer board;
    (int x, int y) whereIs;

    void OnMouseDown()
    {
        board.PlaceAt(whereIs, Card.WithTraits(new Trait("random", Array.Empty<string>(), Array.Empty<string>())));
    }

    public void Configure(BoardRenderer board, (int x, int y) whereIs)
    {
        this.board = board;
        this.whereIs = whereIs;
    }
}