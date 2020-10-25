using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script that handles behavior of everything in the Main Menu scene. Also allows user to go back from level select back to the menu.


public class MainMenuScript : MonoBehaviour
{
    //Initializing variables
    public SceneFaderScript sceneFader;
    public string loadedLevel = "LevelSelect";
    



    // ************ HELPER FUNCTIONS ************
    //When Play button is pressed, sceneFader loads the level select screen.
    public void Play()
    {
        // Debug.Log("Play pressed");
        //SceneManager.LoadScene(loadedLevel);
        sceneFader.FadeTo(loadedLevel);
    }


    //When Quit is pressed, game ends (In the Unity Inspector, displays a Debug.Log statement instead).
    public void Quit()
    {
        Debug.Log("Quit button pressed!");
        Application.Quit();
    }

    
}
