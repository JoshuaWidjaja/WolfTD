using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public static Transform[] pointsArray;

    private void Awake()
    {
        pointsArray = new Transform[transform.childCount];
        for (int i = 0; i < pointsArray.Length; i++)
        {
            pointsArray[i] = transform.GetChild(i);
        }
    }
}
