using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static bool gameOverStatus;
    public GameObject gameOverUI;


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
}
