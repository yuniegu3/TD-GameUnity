using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target; // again, target is enemies and this is private because we dont want ppl changing our targets.

    //header makes it look so much neater and cleaner when viewing these assests in unity.
    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    //using the header really makes reading my own scripts easy!
    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy"; //this is a tag that i will add in unity that I will attach to enemyPrefab.

    public Transform partToRotate; // this is the part of the turret that will be rotating. This is a empty gameobject in unity. This is the parent of head(turret head) and firepoint(object) and it is located right at the joined place between turret base and turret head.
    public float turnSpeed = 10f;

    public GameObject bulletPrefab; // bullet prefab gameobject
    public Transform firePoint; // empty gameobject placed near the barrel of the turret.



	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //invokes the method UpdateTarget in 0f seconds, then repeatedly every 0.5f repeatRate seconds..
	}
	
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //query enemies by tag("Enemy")
        float shortestDistance = Mathf.Infinity; //if we dont have enemy, we have infinite shortest range
        GameObject nearestEnemy = null; // start with nearest enemy is null (because they havent spawned yet..they spawn after 2f)
        foreach (GameObject enemy in enemies) // each loop! for enemies.
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //gets the distance from x,y,z from start position(turret) to enemy position.
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy; // if distance to enemy is less then shortest distance, that enemy is set to shortestDistance
                nearestEnemy = enemy; // then, enemy is set to the nearestEnemy.
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) // if nearest enemy is not null and shortestDistance is  less or equal to the range
        {
            target = nearestEnemy.transform; // we set target to nearest enemy.
        }   else
        {
            target = null; //need this else statement because if there are no enemys in near distance, it will keep the target even out of range.
        }
    }

	// Update is called once per frame
	void Update () {
        if (target == null) 
            return;

        Vector3 dir = target.position - transform.position; // getting the direction between target(enemy) and turret.
        // Creates a rotation with the specified forward and upwards directions. Quaternion.LookRotation(dir);
        // Quaternions are used to represent rotations.
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        // Lerp is built into Unity. It makes rotation/transforms smooth
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //converts to euler Angles
        //The rotation as Euler angles in degrees. The x, y, and z angles represent a rotation z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis.
        partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 90f); // rotates the y axis according to rotation(euler angle set) for the gameobject partToRotate.
        // x is not moving so its 0f, y is moving accordingly to movement of target direction and z was needed the way I set up my turret. If 0f, it will turn my turret sideways.


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; //when bullet is fired, firecountdown is 1 (made it / firerate so that way we can customize this later to have slower/faster loading turrets)
        }
        fireCountdown -= Time.deltaTime; // firecountdown is - by 1 meters per second instead of 1 meters per frame
	}

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //we instantiate bulletPrefab at the firepoint position.
        Bullet bullet = bulletGO.GetComponent<Bullet>();//Returns the component of Type type if the game object has one attached (which is Bullet)

        if (bullet != null)
            bullet.Chase(target); // bullet chases the target.
    }

	void OnDrawGizmosSelected ()
    // Gizmos is something built into unity.
	{
        Gizmos.color = Color.red; // the wiresphere color showing range is red.
        Gizmos.DrawWireSphere(transform.position, range); // shows a wiresphere of the range from turret when selected.
	}
}
