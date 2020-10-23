using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//File contains variables and information regarding player stats during the game.
public class PlayerInfoScript : MonoBehaviour
{
    //Intializing variables
    public static int currency;
    public int startingCurrency = 500;
    public static int lives;
    public int startingLives = 20;
    public static int waveCounter;


    // Start is called before the first frame update
    //Sets currency and lives to their starting default values. Also sets the wave counter to wave 0, then counts down to wave 1.
    void Start()
    {
        currency = startingCurrency;
        lives = startingLives;
        waveCounter = 0;
    }

}
