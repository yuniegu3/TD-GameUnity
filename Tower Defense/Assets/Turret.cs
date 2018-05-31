﻿using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; //if we dont have enemy, we have inifinit shortest range
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }   else
        {
            target = null; //need this else statement because if there are no enemys in near distance, it will keep the target even out of range.
        }
    }

	// Update is called once per frame
	void Update () {
        if (target == null)
            return;
	}

	private void OnDrawGizmosSelected ()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}
}
