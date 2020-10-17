using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float baseSpeed = 10f;
    
    [HideInInspector]
    public float speed;
    public float baseHealth = 100;
    private float health;
    public int killReward = 5;
    public bool confirmDeath = false;
    public GameObject deathParticles;

    [Header("Unity UI")]
    public Image healthbar;
    
    

    private void Start()
    {
        speed = baseSpeed;
        health = baseHealth;
    }

    private void Update()
    {

    }


    public void takeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthbar.fillAmount = health / baseHealth;
        if (health <= 0 && confirmDeath == false)
        {
            killEnemy();
        }
    }

    public void slowEffect(float slowAmount)
    {
        speed = baseSpeed * (1f - slowAmount);
    }

    void killEnemy()
    {
        confirmDeath = true;
        GameObject deathEffect = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        WaveSpawnerScript.enemyCounter--;
        Destroy(deathEffect, 5f);
        PlayerInfoScript.currency += killReward;
        Destroy(gameObject);
    }
}
