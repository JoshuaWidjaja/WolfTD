using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script that handles the behavior of the SceneFader
public class SceneFaderScript : MonoBehaviour
{
    //Intializing variables. 
    public Image imageObj;
    public AnimationCurve fadeCurve;

    
    // Start is called before the first frame update
    //When scene fader is needeed, calls the proper Coroutine
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    //If this function is called, we use newScene parameter to set which scene to fade to next.
    public void FadeTo(string newScene)
    {
        StartCoroutine(FadeOut(newScene));
    }


    //Coroutine that fades current scene into black.
    IEnumerator FadeIn()
    {
        float timeVal = 1f;
        while (timeVal > 0)
        {
            timeVal -= Time.deltaTime;
            float alphaVal = fadeCurve.Evaluate(timeVal);
            imageObj.color = new Color(0f, 0f, 0f, alphaVal);
            yield return 0;
        }


    }

    //Coroutine that fades from black into the new chosen scene, then loads it  
    IEnumerator FadeOut(string newScene)
    {
        float timeVal = 0f;
        while (timeVal < 1f)
        {
            timeVal += Time.deltaTime;
            float alphaVal = fadeCurve.Evaluate(timeVal);
            imageObj.color = new Color(0f, 0f, 0f, alphaVal);
            yield return 0;
        }

        SceneManager.LoadScene(newScene);


    }
}
