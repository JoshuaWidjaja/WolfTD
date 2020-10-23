using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the Level Select screen
public class LevelSelectorScript : MonoBehaviour
{
    //Initializing variables and Button array.
    public SceneFaderScript sceneFader;

    public Button[] levelButtons;
    // Start is called before the first frame update
    //Checks to see what the farthest level reached by the player is. Unlocks the levels in level select based on what that number is. Other levels remained locked until cleared by player.
    //By default, only first level is unlocked.
    void Start()
    {
        int farthestLevelReached = PlayerPrefs.GetInt("farthestLevelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > farthestLevelReached)
            {
                levelButtons[i].interactable = false;
            }
        }

    }


    //When a level button is selected, the sceneFader then fades to that level.
    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
