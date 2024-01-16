using System;
using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;

public class FakeHand : MonoBehaviour
{
    [SerializeField] private bool isFriend;

    private Trait Friend => new("friend", new[] { "friend" }, new[] { "enemyOfFriend" });
    private Trait EnemyOfFriend => new("enemyOfFriend", Array.Empty<string>() , new[] { "friend" });
    public Card NextCard => Card.WithTraits( isFriend ? Friend : EnemyOfFriend);
}