using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI Script that eases display of currency onto the UI.
public class CurrencyUIScript : MonoBehaviour
{
    public Text currencyText;
    // Start is called before the first frame update
 
    // Update is called once per frame
    //Checks what player currency is supposed to be, changes it to a string, and adds dollar sign to be displayed onto UI.
    void Update()
    {
        currencyText.text = "$" + PlayerInfoScript.currency.ToString();
    }
}
