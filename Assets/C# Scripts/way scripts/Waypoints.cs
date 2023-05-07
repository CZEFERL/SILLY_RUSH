using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform[] points { get; set; }
    public bool XDirStart { get; set; }
    public bool YDirStart { get; set; }
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


        if (Mathf.Abs(points[1].position.x - points[0].position.x) < 0.5)
        {
            YDirStart = (points[1].position.y - points[0].position.y) > 0;
            XDirStart = (points[2].position.x - points[1].position.x) > 0;
        }
        else
        {
            XDirStart = (points[1].position.x - points[0].position.x) > 0;
            YDirStart = (points[2].position.y - points[1].position.y) > 0;
        }
    }
}
