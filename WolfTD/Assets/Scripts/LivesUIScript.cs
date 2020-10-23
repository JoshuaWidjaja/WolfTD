using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script handling the UI for the remaining player livese
public class LivesUIScript : MonoBehaviour
{
    //Initializing variables
    public Text livesText;
  
    // Update is called once per frame
    //Updates and displays the lives every frame based on what the lives variable is in PlayerInfoScript
    void Update()
    {

        livesText.text = "LIVES: " + PlayerInfoScript.lives; 
    }
}
