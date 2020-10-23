using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script that is specifically for displaying the Rounds Survived during a win level or game over scenario
public class RoundSurvivedScript : MonoBehaviour
{
    //Intializing the text variables
    public Text waveCounterText;
    public int wavesSurvived;

    //At start, we assign wavesSurvived to what is currently stated in the PlayerInfo script.
    void Start()
    {
        wavesSurvived = PlayerInfoScript.waveCounter;
    }
    
    //When the UI is enabled, want the round counter to tick upwards in animation form.
    void OnEnable()
    {
        StartCoroutine(AnimateText());
        //waveCounterText.text = wavesSurvived.ToString();
    }

    //Animate text coroutine starts from 0 and counts up to the numer of waves that the player survived.
    IEnumerator AnimateText()
    {
        waveCounterText.text = "0";
        int startRound = 0;
        yield return new WaitForSeconds(.7f);
        while (startRound < wavesSurvived)
        {
            startRound++;
            waveCounterText.text = startRound.ToString();
            yield return new WaitForSeconds(.05f);
        }
    }
}
