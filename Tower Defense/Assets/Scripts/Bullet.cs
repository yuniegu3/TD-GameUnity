using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 30f;

    public float damage = 50f;

    public GameObject impactEffect; //this is the cool bullet impact effect ive made from unity (particles object)

    public void Chase (Transform _target)
    {
        target = _target;
    }
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject); // destroys bullet if target is destroyed/null
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime; 

        if (dir.magnitude <= distanceThisFrame) // magnitude returns the length of this vector(dir)
            // if length of the dir is less or equal to in this case, 70f in deltaTime, hitTarget method is called.
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

	}

    void HitTarget ()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f); // after 2f, effectIns(particles object) is destroyed.

        Damage(target);

        Destroy(gameObject); // bullet is destroyed.

        return;

    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }



}
