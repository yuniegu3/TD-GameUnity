using UnityEngine;

public class Enemy : MonoBehaviour {
    //speed is float so we can effectively change speed.
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

	void Start()
	{
        target = Waypoints.points[0];// can call waypoints this way b/c its public [0] sets waypoint to first waypoint
	}

	private void Update()
    {   //Vector3 gives (x,y,z) Translate moves into that direction
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //normalize lets you have consistant speed. *Time lets you go with the time(actual time) not by fps

        // switches to another waypoint if target position is 0.2f away. The tutorial said do 0.4f instead of 0.2f (if you get error) because computer can be off a bit.
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length -1)//if wavepoint is at the end
        {
            Destroy(gameObject); //destroys the enemy gameobject if wavepoint is at the end
            return; //Destroy takes some time to destroy object so it might switch over to next code if not returned
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];//switches to the next waypoint(target switches)
    }
    
}
