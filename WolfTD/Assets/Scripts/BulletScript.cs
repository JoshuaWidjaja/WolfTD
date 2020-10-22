using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles the mechanics for projectiles shot by turrets.
public class BulletScript : MonoBehaviour
{
    //Initializing variables

    public float speed = 60f;
    public float blastRadius = 0;
    public int damage = 50;
    public GameObject impactEffectPrefab;

    private Transform target;

    // Update is called once per frame
    //If no target exists, destroy the projectile. Else, move the projectile toward the target. If we are close enough to the target, call HitTarget().
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);
    }


    // ************ HELPER FUNCTIONS ************

    //Displays particle effects for the projectile on impact. Damages the enemy, and then destroys the particles and the projectile object.
    void HitTarget()
    {
        GameObject bulletEffects = (GameObject)Instantiate(impactEffectPrefab, transform.position, transform.rotation);
        Destroy(bulletEffects, 4.5f);

        if (blastRadius > 0)
        {
            Explode();
        }
        else
        {
            DamageEnemy(target);
        }
       
        Destroy(gameObject);
    }

    //Helper function that calls the takeDamage functions located in Enemy script to have unit take damage based on projectile hit.
    void DamageEnemy(Transform enemy)
    {
        EnemyScript typeEnemy = enemy.GetComponent<EnemyScript>();
        if (typeEnemy != null){
            typeEnemy.takeDamage(damage);
        }
       
    }

    //Creates collider array that takes in all objects overlapping the area. If any of the objects has tag Enemy, call DamageEnemy function on that location
    void Explode()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                DamageEnemy(collider.transform);
            }
        }
    }

    //Causes the turret to "look" in the direction of the target.
    public void SeekTarget(Transform targetObject)
    {
        target = targetObject;
    }

    //Debugging function, used to see explosion range of the missile projectile when selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
    
}
