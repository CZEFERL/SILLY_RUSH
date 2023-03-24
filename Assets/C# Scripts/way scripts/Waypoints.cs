using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    public static bool XDirStart, YDirStart;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }

        if (Waypoints.points[1].position.x - Waypoints.points[0].position.x == 0)
        {
            YDirStart = (Waypoints.points[1].position.y - Waypoints.points[0].position.y) > 0;
            XDirStart = (Waypoints.points[2].position.x - Waypoints.points[1].position.x) > 0;
        }
        else
        {
            XDirStart = (Waypoints.points[1].position.x - Waypoints.points[0].position.x) > 0;
            YDirStart = (Waypoints.points[2].position.y - Waypoints.points[1].position.y) > 0;
        }
    }
}
