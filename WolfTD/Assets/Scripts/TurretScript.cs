using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
//Turret script contains the information needed for the turret to function as well as the default stats for each different turret.
public class TurretScript : MonoBehaviour
{
    //Initializing variables that every turret will have.
    private Transform target;
    private EnemyScript targetEnemy;
    
    //Bullet Attributes apply to non-laser turrets while laser attributes apply to the laser turrets.
    [Header("General Attributes")]
    public float turretRange = 15f;
    

    [Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Laser Attributes")]
    public bool useLaser = false;
    public int damageTick = 30;
    public float slowAmount = .5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    //Sets up the enemyTag so that we can easily tag all enemies, allowing turrets to accurately behave by facing them and firing at them.
    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform rotatingObject;
    public float turnSpeed = 6f;

    public Transform bulletSpawnPoint;



    // Start is called before the first frame update
    //Checks to see if we should update the target 3 times a frame
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.33f);
       
    }

    // Update is called once per frame
    //If there is no target, we stop firing any projectile and return. Else, we lock on to that target.
    //If type of turret is a laser turret, we call the Laser() functions, else, we call Shoot() to fire a projectile.
    //Fire rate of projectile depends on the fireRate of the turret.
    void Update()
    {
        if (target == null)
        {
            if(useLaser == true)
            {
                if (lineRenderer.enabled == true)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {

            if (fireCooldown <= 0)
            {
                Shoot();
                fireCooldown = 1 / fireRate;
            }
        }

        fireCooldown -= Time.deltaTime;
    }
    

    //Debugging funtions that displays the range of turrets when clicked on.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }

    //This functions creates an array of enemies that are currently in the game. Then it calculates the shortest distance from each turret to each enemy in the array.
    //If no enemies exist, we set target value to null, and don't need to fire. Else, turret sets target to the closest enemy.
    void UpdateTarget()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemyList)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= turretRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyScript>();
        }
        else
        {
            target = null;  
        }
    }

    //This functions makes it so that the turret will look in the direction of the target and rotate in the direction that target moves.
    void LockTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotationVal = Quaternion.Lerp(rotatingObject.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingObject.rotation = Quaternion.Euler(0, rotationVal.y, 0);
    }

    //Shoot function shoots a bullet/missile projectile towards the target.
    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletScript bullet = bulletGameObject.GetComponent<BulletScript>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }
    }

    //Laser functions is fore laser turrets. Shoots in direction of target and slows them based on the slowAmount of the turret.
    //Also enables the lineRenderer, which is the laser itself and makes sure that the laser is always going towards the center of the target.
    void Laser()
    {
        targetEnemy.TakeDamage(damageTick * Time.deltaTime);
        targetEnemy.SlowEffect(slowAmount);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, bulletSpawnPoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 impactDirection = bulletSpawnPoint.position - target.position;
        impactEffect.transform.position = target.position + impactDirection.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(impactDirection);
        
    }


}
