using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//WaveSpawner script handles the spawning of differnt waves as handles certain UI elements, such as the countdown between waves.
public class WaveSpawnerScript : MonoBehaviour
{
    //Intializing variables. Important ones includde the startSpawnPoint and the Waves array, which keeps track of the different waves to spawn in a level.
    public static int enemyCounter;
    public WaveClassScript[] waves;
    public Transform startSpawnPoint;
    public Text countdownText;
    public float defaultTimer = 5f;
    public GameManagerScript gameManager;

    private float countdown = 2f;
    private int waveNumber = 0;

    //At start, make sure that the number of enemies is set to 0.
    private void Start()
    { 
        enemyCounter = 0;
    }
         
    //Every frame, check to see if player is at GameOver status and if there are alive enemies on the screen. If both are false, and the waveNumber is at the designated last wave,
    //call WinLevel() and disable the spawner. Else, checks to see if countdown is 0, and then spawns the wave and resets the countdown if it is. If countdown is not 0, continue to
    //count down and update the UI for the player accordingly.
    private void Update()
    {
        if (PlayerInfoScript.lives <= 0)
        {
            return;
        }

        if(enemyCounter > 0)
        {
            return;
        }

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = defaultTimer;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        countdownText.text = string.Format("{0:00.00}", countdown);
    }

    //Coroutine that updates the player's waveCounter and spawns the next wave of the level. Updates as the game goes on.
    IEnumerator SpawnWave()
    {
        //Debug.Log("Incoming Wave Detected!");
        
        PlayerInfoScript.waveCounter++;
        WaveClassScript wave = waves[waveNumber];
        enemyCounter = wave.spawnCount;

        for (int i = 0; i < wave.spawnCount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.spawnRate);
        }

        waveNumber++;
    }

    //Functions that instantiates an enemy  at the starting spawn point.
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, startSpawnPoint.position, startSpawnPoint.rotation);
    }
}
