using UnityEngine;

public class Connection : MonoBehaviour
{
    LineRenderer LineRenderer => GetComponentInChildren<LineRenderer>();
    public void Configure(((int x, int y) from, (int x, int y) to) points)
    {
        LineRenderer.SetPosition(0, new(points.from.x + (points.from.x * 0.2f), points.from.y + (points.from.y * 0.2f), 0));
        LineRenderer.SetPosition(1, new(points.to.x + (points.to.x * 0.2f), points.to.y + (points.to.y * 0.2f), 0));
    }

}