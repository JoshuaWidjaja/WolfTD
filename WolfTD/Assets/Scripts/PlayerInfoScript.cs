using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoScript : MonoBehaviour
{
    public static int currency;
    public int startingCurrency = 500;
    public static int lives;
    public int startingLives = 20;
    public static int waveCounter;
    // Start is called before the first frame update
    void Start()
    {
        currency = startingCurrency;
        lives = startingLives;
        waveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
