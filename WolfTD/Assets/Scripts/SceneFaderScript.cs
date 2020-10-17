using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFaderScript : MonoBehaviour
{

    public Image imageObj;
    public AnimationCurve fadeCurve;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FadeTo(string newScene)
    {
        StartCoroutine(FadeOut(newScene));
    }

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
