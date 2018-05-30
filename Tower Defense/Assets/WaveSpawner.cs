using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab; //maybe edit later to levels or diff enemys depending on lvl etc

    public Transform spawnPoint; 

    public float timeBetweenWaves = 5f; // testing on 5f but change later
    private float countdown = 2f;

    private int waveIndex = 0;

	private void Update ()
	{
		 if (countdown <= 0f) // when countdown is 0 or less then 0 starts spawning.
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime; // counts down
	}

    IEnumerator SpawnWave () //Ienumerator lets you pause this code
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //spawns enemiesin .3 secs
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
