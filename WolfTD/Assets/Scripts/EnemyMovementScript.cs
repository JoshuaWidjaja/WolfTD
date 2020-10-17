using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovementScript : MonoBehaviour
{
    private Transform moveTarget;
    private int waypointIndex = 0;
    private EnemyScript enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
        moveTarget = WaypointScript.pointsArray[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerInfoScript.lives <= 0)
        {
            return;
        }

        Vector3 dir = moveTarget.position - transform.position;
        //Normalized makes it always have the same legnth
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, moveTarget.position) <= 0.5f)
        {
            GetNextWayPoint();
        }

        enemy.speed = enemy.baseSpeed;
    }

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

    void endPath()
    {
        PlayerInfoScript.lives--;
        WaveSpawnerScript.enemyCounter--;
        Destroy(gameObject);
        
    }
}
