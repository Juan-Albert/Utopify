using System;
using Codice.Client.BaseCommands.BranchExplorer.Layout;
using Runtime.Domain;
using UnityEngine;

public class Connection : MonoBehaviour
{
    LineRenderer LineRenderer => GetComponentInChildren<LineRenderer>();
    public void Configure(((int x, int y) from, (int x, int y) to) points, Card.Relationship adwgf)
    {
        LineRenderer.SetPosition(0, new(points.from.x + (points.from.x * 0.2f), points.from.y + (points.from.y * 0.2f), 0));
        LineRenderer.SetPosition(1, new(points.to.x + (points.to.x * 0.2f), points.to.y + (points.to.y * 0.2f), 0));

        ChangeColor(ColorOf(adwgf));
    }

    void ChangeColor(Color whichOne)
    {
        LineRenderer.startColor = whichOne;
        LineRenderer.endColor = whichOne;
    }
    
    private Color ColorOf(Card.Relationship adwgf)
    {
        switch (adwgf)
        {
            case Card.Relationship.Neutral:
                return Color.yellow;
            case Card.Relationship.Positive:
                return Color.green;
            case Card.Relationship.Negative:
                return Color.red;
            default:
                throw new NotSupportedException($"No existe una relacion entre cartas de tipo {adwgf}");
        }
    }
}