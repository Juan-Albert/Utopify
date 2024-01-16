using System;
using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;

public struct TraitLook
{
    public string id;
    public Color howLooksLike;

    public TraitLook(string id, Color howLooksLike)
    {
        this.id = id;
        this.howLooksLike = howLooksLike;
    }
}

public class PlacedCard : MonoBehaviour
{
    List<TraitLook> looks = new List<TraitLook> 
        { 
            new("friend", Color.green),
            new("enemyOfFriend", Color.red)
        };

    public void Depict(Card toBeDepicted)
    {
        
    }
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