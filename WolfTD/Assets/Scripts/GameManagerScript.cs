using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManagerScript, handles many of the higher level functions of the game including Game Over states and next level states.
public class GameManagerScript : MonoBehaviour
{
    //Intializing variables. For the first level, nextLevel and nextLevelInt refer to the information for level 2, must be manually adjusted for future levels.
    public static bool gameOverStatus;
    public GameObject gameOverUI;
    public GameObject winLevelUI;
    
  
    // Start is called before the first frame update
    //Initially sets gameOver to False, since game is being played
    void Start()
    {
        gameOverStatus = false;
    }

    // Update is called once per frame
    //If gameOverStatus = True, ends the loop, else checks if player lives is <= 0 and if so, calls gameOver() function.
    void Update()
    {
        if (gameOverStatus)
        {
            return;
        }

        //Debugging code
       /* if (Input.GetKeyDown("e")){
            gameOver();
        }*/

        if(PlayerInfoScript.lives <= 0)
        {
            GameOver();
        }
    }

    // ************ HELPER FUNCTIONS ************
    
    //When gameOver() is called, sets the gameOvereStatus = true and enables the gameOverUI.
    void GameOver()
    {
        gameOverStatus = true;
        gameOverUI.SetActive(true);
        
    }

    //Called when player beat the level. Updates the progression of the player so that they can access a new level from the level Selection screen.
    //Also fades to the next level if existing.
    public void WinLevel()
    {
        Debug.Log("You beat the level!");
        gameOverStatus = true;
        winLevelUI.SetActive(true);


    }
}
