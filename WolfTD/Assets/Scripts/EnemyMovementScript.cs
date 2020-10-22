using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script handles eenemy movement towards goal

//This line of code will automatically add component EnemyScript to the gameObbject if it is not already existing for some reason with this script on it.
[RequireComponent(typeof(EnemyScript))]
public class EnemyMovementScript : MonoBehaviour
{
    //Initializing variables
    private Transform moveTarget;
    private int waypointIndex = 0;
    private EnemyScript enemy;

    // Start is called before the first frame update
    //Assigns enemy variable to the EnemyScript component and assigns the first movement waypoint to the gameObject.
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        moveTarget = WaypointScript.pointsArray[0];
    }

    // Update is called once per frame
    //If player has no more lives, stop movement for all enemies. Else, continuously move towards next waypoints with given speed variable.
    private void Update()
    {
        if (PlayerInfoScript.lives <= 0)
        {
            return;
        }

        Vector3 dir = moveTarget.position - transform.position;
        //Normalized makes it always have the same legnth
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //If distance between target is <=0.5f, seek next wayPoint to move towards. This makes it so enemies don't pause at each waypoint once reached.
        if (Vector3.Distance(transform.position, moveTarget.position) <= 0.5f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.baseSpeed;
    }

    // ************ HELPER FUNCTIONS ************

    //Helper function that finds the next waypoint for object to move to. If it's at the last endpoint (goal) we call endPath() else continue moving towards end.
    void GetNextWayPoint()
    {
        if (waypointIndex >= WaypointScript.pointsArray.Length - 1)
        {
            endPath();
            return;
        }
        waypointIndex++;
        moveTarget = WaypointScript.pointsArray[waypointIndex];
    }

    //If enemy reaches last waypoint, subtract 1 from player lives, 1 from the enemyCount, and destroy the object.
    void endPath()
    {
        PlayerInfoScript.lives--;
        WaveSpawnerScript.enemyCounter--;
        Destroy(gameObject);
        
    }
}
