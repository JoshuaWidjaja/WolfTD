using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lets Unity know that this is something to save and load and show in the inspector
[System.Serializable]
public class WaveClassScript
{
    public GameObject enemy;
    public int spawnCount;
    public float spawnRate;

}
