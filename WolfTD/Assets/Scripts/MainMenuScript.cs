﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public SceneFaderScript sceneFader;
    public string loadedLevel = "LevelScene";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        // Debug.Log("Play pressed");
        //SceneManager.LoadScene(loadedLevel);
        sceneFader.FadeTo(loadedLevel);
    }

    public void Quit()
    {
        Debug.Log("Quit button pressed!");
        Application.Quit();
    }
}
