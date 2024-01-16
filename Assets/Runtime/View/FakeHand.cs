using System.Collections.Generic;
using Runtime.Domain;
using UnityEngine;

public class FakeHand : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private List<string> friends;
    [SerializeField] private List<string> enemies;
    
    public Card NextCard => Card.WithTraits(new Trait(id, friends, enemies));
}