using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public GameObject UI;
    public Text waveCounterText;
    public SceneFaderScript sceneFader;
    public int wavesSurvived;
    public string menuScene = "MainMenuScene";
    // Start is called before the first frame update
    void Start()
    {
        wavesSurvived = PlayerInfoScript.waveCounter - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        waveCounterText.text = wavesSurvived.ToString();
       
        

    }

    public void Retry()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);  
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuScene);
        Debug.Log("Menu button clicked");
    }
}
