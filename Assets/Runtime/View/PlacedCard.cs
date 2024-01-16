using System;
using System.Collections.Generic;
using System.Linq;
using Runtime.Domain;
using UnityEngine;
using UnityEngine.Assertions;

public class PlacedCard : MonoBehaviour
{
    List<TraitLook> looks = new List<TraitLook> 
    { 
        new("friend", Color.green),
        new("enemyOfFriend", Color.red)
    };

    public void Depict(Card toBeDepicted) 
        => ChangeColor(ColorOf(toBeDepicted));

    void ChangeColor(Color colorOf) 
        => GetComponentsInChildren<Renderer>().Single().sharedMaterial.color = colorOf;

    Color ColorOf(Card toBeDepicted)
    {
        Assert.IsTrue(toBeDepicted.Traits.Any());
        
        return looks.Single(asfasf).howLooksLike;

        bool asfasf(TraitLook x) => toBeDepicted.Traits.First().id.Equals(x.id);
    }
}