using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject UI;
    public SceneFaderScript sceneFader;
    public string menuScene = "MainMenuScene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        
    }

    public void TogglePause()
    {
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }

    public void MenuButton()
    {
        Debug.Log("Menu button clicked!");
        TogglePause();
        sceneFader.FadeTo(menuScene);
    }

    public void RetryButton()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        // WaveSpawnerScript.
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
