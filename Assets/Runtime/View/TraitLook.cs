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