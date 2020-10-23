using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lets Unity know that this is something to save and load and show in the inspector
[System.Serializable]

//Allows us to customize waves with different enemy type, amount to spawn and the rate to spawn at. 
//Potential to add make into a class or a blueprint to allow for different types/numbers to spawn in the same wave. 
public class WaveClassScript
{
    public GameObject enemy;
    public int spawnCount;
    public float spawnRate;

}
