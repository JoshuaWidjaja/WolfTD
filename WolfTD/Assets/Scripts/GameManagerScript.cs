using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static bool gameOverStatus;
    public GameObject gameOverUI;
    public string nextLevel = "LevelTwoScene";
    public int nextLevelInt = 2;
    public SceneFaderScript sceneFader;
    

    // Start is called before the first frame update
    void Start()
    {
        gameOverStatus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverStatus)
        {
            return;
        }

       /* if (Input.GetKeyDown("e")){
            gameOver();
        }*/

        if(PlayerInfoScript.lives <= 0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        gameOverStatus = true;
        gameOverUI.SetActive(true);
        
    }

    public void WinLevel()
    {
        Debug.Log("You beat the level!");
        if (nextLevelInt > PlayerPrefs.GetInt("farthestLevelReach", 1))
        {
            PlayerPrefs.SetInt("farthestLevelReached", nextLevelInt);
        }
        sceneFader.FadeTo(nextLevel);


    }
}
