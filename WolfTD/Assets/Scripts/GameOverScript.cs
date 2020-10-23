using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script handles the assignment of variables for the Game Over UI.
public class GameOverScript : MonoBehaviour
{
    //Initializing variables 
    public GameObject UI;
    public Text waveCounterText;
    public SceneFaderScript sceneFader;
    public int wavesSurvived;
    public string menuScene = "MainMenuScene";
    
    // Start is called before the first frame update
    //When Game Over screen appears, wavesSurvived is set to thee current wave subtracted by 1.
    void Start()
    {
        wavesSurvived = PlayerInfoScript.waveCounter - 1;
    }

    // ************ HELPER FUNCTIONS ************

  

    //Called when the "Retry" button is selected in the Game Over menu. Fades and then restarts the current level.
    public void Retry()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);  
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Called when the "Menu" button is selected in the Game Over menu. Then fades back to the main menu screen.
    public void Menu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuScene);
        Debug.Log("Menu button clicked");
    }
}
