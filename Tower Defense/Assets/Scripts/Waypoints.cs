using UnityEngine;

public class Waypoints : MonoBehaviour {
   
    public static Transform[] points; // transform is something in unity. Every object is a transform because it moves/can move. [] makes it a array.
    // Awake(private cuz its only being used in waypoints) loops through all the waypoints and stores that into points
	private void Awake ()
	{
        points = new Transform[transform.childCount]; //points(array) is new transform with transform.the number of children the Transform has.
        for (int i = 0; i < points.Length; i++) // for loop loops through the entire array and sets 
        {
            points[i] = transform.GetChild(i); // GetChild returns a transform child by index(i)
        }
    }
}
