﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrencyUIScript : MonoBehaviour
{
    public Text currencyText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "$" + PlayerInfoScript.currency.ToString();
    }
}
