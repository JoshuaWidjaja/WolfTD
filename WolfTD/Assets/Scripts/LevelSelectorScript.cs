using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorScript : MonoBehaviour
{
    public SceneFaderScript sceneFader;

    public Button[] levelButtons;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }
}
