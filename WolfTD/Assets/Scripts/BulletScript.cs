using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Transform target;
    
    public float speed = 60f;
    public float blastRadius = 0;
    public int damage = 50;
    public GameObject impactEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    void DamageEnemy(Transform enemy)
    {
        EnemyScript typeEnemy = enemy.GetComponent<EnemyScript>();
        if (typeEnemy != null){
            typeEnemy.takeDamage(damage);
        }
       
    }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
    public void SeekTarget(Transform targetObject)
    {
        target = targetObject;
    }
}
