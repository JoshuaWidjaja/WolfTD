using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TurretScript : MonoBehaviour
{
    private Transform target;
    private EnemyScript targetEnemy;
    
    
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


    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    public Transform rotatingObject;
    public float turnSpeed = 6f;

    public Transform bulletSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.33f);
    }

    // Update is called once per frame
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

        lockTarget();

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
    


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }

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

    void lockTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotationVal = Quaternion.Lerp(rotatingObject.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingObject.rotation = Quaternion.Euler(0, rotationVal.y, 0);
    }
    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletScript bullet = bulletGameObject.GetComponent<BulletScript>();

        if (bullet != null)
        {
            bullet.SeekTarget(target);
        }

       
    }
    void Laser()
    {
        targetEnemy.takeDamage(damageTick * Time.deltaTime);
        targetEnemy.slowEffect(slowAmount);
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
