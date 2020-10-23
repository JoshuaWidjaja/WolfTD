using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores the different waypoints for enemies to follow in pointsArray.
public class WaypointScript : MonoBehaviour
{
    //Initializing pointsArray
    public static Transform[] pointsArray;

    //On start, creates and assigns pointsArray to an empty array the size of the number of waypoints. Then, assigns each index to the waypoints position, in order.
    private void Awake()
    {
        pointsArray = new Transform[transform.childCount];
        for (int i = 0; i < pointsArray.Length; i++)
        {
            pointsArray[i] = transform.GetChild(i);
        }
    }
}
