using UnityEngine;
using System.Collections; //lets you use the function IEnumerator
using UnityEngine.UI; //lets you use the UI -Text 

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab; //maybe edit later to levels or diff enemys depending on lvl etc - this is my blue ball of enemies

    public Transform spawnPoint; //this is a empty/not shaped gameobject that I've made(inside start object)

    public float timeBetweenWaves = 5f; // testing on 5f but change later
    private float countdown = 2f; // first time, spawns in 2f and then, spawns every 5f

    public Text waveCountdownText; // the text that shows countdown (this is UI object)

    private int waveIndex = 0;

	private void Update ()
	{
		 if (countdown <= 0f) // when countdown is 0 or less then 0 starts spawning.
        {
            StartCoroutine(SpawnWave());// StartCoroutine(IEnumerator routine). Starts IEnumerator..you can pause this code via yield
            countdown = timeBetweenWaves; // once wave is spawned, the countdown changes to 5 instead of 2f.
        }
        countdown -= Time.deltaTime; // counts down/ from Unity Doc : If you add or subtract to a value every frame chances are you should multiply with Time.deltaTime. When you multiply with Time.deltaTime you essentially express: I want to move this object 10 meters per second instead of 10 meters per frame.

        waveCountdownText.text = Mathf.Floor(countdown).ToString(); //Mathf.Floor cuts floats and rounds down to w/e integer
        //waveCountdownText.text the .text can be called because that object was created as a text(UI) in unity.
	}

    IEnumerator SpawnWave () //Ienumerator lets you pause this code via yield
    {
        waveIndex++; // enemy count increases by 1 every time a wave is spawned.
        PlayerStats.Rounds++;
        for (int i = 0; i < waveIndex; i++) // for loop that will go on forever. Will need to put a end later. Right now, it will keep going.
        {
            SpawnEnemy(); // so enemies will keep spawning forever because waveindex will always increase.
            yield return new WaitForSeconds(0.5f); //spawns enemies in .5f so enemies dont come out clumped together from one spot
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); //starts spawning enemies 
        // enemyPrefab is a object i've made in unity(the blue balls) spawnpoint is an object ive made in unity (it is inside start object) and the rotation is the orientation of the spawnpoint.
    }
}
