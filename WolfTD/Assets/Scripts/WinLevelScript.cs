using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Handles UI elements for beating/completing each level
public class WinLevelScript : MonoBehaviour
{
    //Intializing variables. menuScene, nextLevel must be updated manually for each level. These values are intialized for level 1.
    public SceneFaderScript sceneFader;
    public string menuScene = "MainMenuScene";
    public string nextLevel = "LevelTwoScene";
    public int nextLevelInt = 2;
    
    //If player clicks the continue button, updates the farthestLevelReached for level Select functoin and then fades to the next level.
    public void Continue()
    {
        if (nextLevelInt > PlayerPrefs.GetInt("farthestLevelReached", 1))
        {
            PlayerPrefs.SetInt("farthestLevelReached", nextLevelInt);
        }
        sceneFader.FadeTo(nextLevel);
    }

    //If menu is clicked, fades back to the main menu.
    public void Menu()
    {
        sceneFader.FadeTo(menuScene);
    }


}
