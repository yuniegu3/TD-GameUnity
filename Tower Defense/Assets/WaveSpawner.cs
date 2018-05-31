using UnityEngine;
using System.Collections; //lets you use the function IEnumerator
using UnityEngine.UI; //lets you use the UI -Text 

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab; //maybe edit later to levels or diff enemys depending on lvl etc

    public Transform spawnPoint; 

    public float timeBetweenWaves = 5f; // testing on 5f but change later
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

	private void Update ()
	{
		 if (countdown <= 0f) // when countdown is 0 or less then 0 starts spawning.
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime; // counts down

        waveCountdownText.text = Mathf.Floor(countdown).ToString(); //Mathf.Floor cuts floats and rounds down to w/e integer
	}

    IEnumerator SpawnWave () //Ienumerator lets you pause this code
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //spawns enemies in .3 secs so enemies dont come out clumped together from one spot
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); //starts spawning enemies
    }
}
