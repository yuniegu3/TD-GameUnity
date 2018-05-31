using UnityEngine;

public class Waypoints : MonoBehaviour {
    //Transform is something changing
    public static Transform[] points;
    // Awake(private cuz its only being used in waypoints) loops through all the waypoints and stores that into points
	private void Awake ()
	{
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
           points[i] = transform.GetChild(i);
        }
    }
}
