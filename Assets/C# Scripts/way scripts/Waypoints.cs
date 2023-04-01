using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    public static bool XDirStart, YDirStart;
    public Transform StartOfPath;
    public Transform EndOfPath;

    void Awake()
    {
        points = new Transform[transform.childCount+2];

        points[0] = StartOfPath;
        for (int i = 0; i < points.Length - 2; i++)
        {
            points[i+1] = transform.GetChild(i);
        }
        points[transform.childCount + 1] = EndOfPath;


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
