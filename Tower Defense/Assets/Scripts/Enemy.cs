using UnityEngine;

public class Enemy : MonoBehaviour {
    //speed is float so we can effectively change speed.
    public float speed = 10f;

    public int health = 100;

    public int value = 50;

    // target & wavepointIndex is private because you dont want users to be able to play around with that. Since our code relies heavily on this and messing around with this will break my whole code.
    private Transform target; //transform is something in unity. Every object is a transform because it moves/can move.
    private int wavepointIndex = 0;

    // starts moving enemies(target)!
	void Start()
	{
        target = Waypoints.points[0];// can call waypoints this way b/c its public [0] sets waypoint to first waypoint
        //enemy will look to go to waypoint 0 first at start.
	}

    public void TakeDamage (int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {   
        PlayerStats.Money += value;
        Destroy(gameObject);
    }


    // update is something that changes/updates.
	private void Update()
    {   //Vector3 gives (x,y,z) Translate moves into that direction
        Vector3 dir = target.position - transform.position; //target position is where target starts. Transform position is position once moved. So the dir(direction variable)
        //is calculated by start.position - moved.position to get the actual distance of direction.
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //normalize lets you have consistant speed so here, moving from point A to point B, speed will be set to w/e your speed is. *Time lets you go with the time(actual time) not by framerate(because if you drop in frame rate and enemies are moving by framerate, it looks glitchy)
        //Translate moves the transform in the direction and distance(dir) of translation. In this case, waypoint is the coordinates.
        //Space.World is something in unity that makes this gameobject move in world space instead of local space. 
        // switches to another waypoint if target position is 0.2f away. The tutorial said do 0.4f instead of 0.2f (if you get error) because computer can be off a bit.
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) // Vector3(gives x,y,z cordinates) .Distance returns the distance between moved position and start position. And if that distance is less than or equal
            //to 0.4f, it moves target to the next waypoint 
        {
            GetNextWaypoint(); //calling this function!! when if statement is met. (when I did 0.2f, the targets kind of got stuck for a bit before moving on to next waypoint.
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length -1)//if wavepoint is at the end (waypoint is a array as defined in Waypoints.cs script)
        {
            EndPath(); //destroys the enemy gameobject if wavepoint is at the end - by gameObject = enemy/target/the blue ball.
            return; //Destroy takes some time to destroy object so it might switch over to next code if not returned. This will make game glitchy
        }

        wavepointIndex++; // index is increased, that way, enemies are moving to the next waypoint after reaching a waypoint if the waypoint is not at end.
        target = Waypoints.points[wavepointIndex];//switches to the next waypoint(target switches)
    }

    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
