using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnerScript : MonoBehaviour
{

    public static int enemyCounter;
    public WaveClassScript[] waves;
    public Transform startSpawnPoint;
    public Text countdownText;
    public float defaultTimer = 5f;
    public GameManagerScript gameManager;

    private float countdown = 2f;
    private int waveNumber = 0;


    private void Start()
    { 
        enemyCounter = 0;
    }
         
    
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

        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, startSpawnPoint.position, startSpawnPoint.rotation);
    }
}
