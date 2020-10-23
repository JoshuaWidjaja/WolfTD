using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This file contains information regarding enemy statistics
public class EnemyScript : MonoBehaviour
{
    //Initializing variables. Some are visible in inspectors wihle some are hidden
    public float baseSpeed = 10f;
    
    [HideInInspector]
    public float speed;
    public float baseHealth = 100;
    private float health;
    public int killReward = 5;
    public bool confirmDeath = false;
    public GameObject deathParticles;

    //Variable that will contain the enemy health bar image in game
    [Header("Unity UI")]
    public Image healthbar;
    
    
    //At start, speed and health of enemy are set to the base values.
    private void Start()
    {
        speed = baseSpeed;
        health = baseHealth;
    }

    private void Update()
    {

    }

    // ************ HELPER FUNCTIONS ************

    //This helper functions subtracts enemy health when they get hit, and adjusts their health bar image as well.
    //If health is below 0 then killEnemy() is called.
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthbar.fillAmount = health / baseHealth;
        if (health <= 0 && confirmDeath == false)
        {
            KillEnemy();
        }
    }

    //Adjusts enemies speed based on slowAmount. Only called when hit by specific turrets: LaserTurret
    public void SlowEffect(float slowAmount)
    {
        speed = baseSpeed * (1f - slowAmount);
    }

    //When called, this functions instantiates the death particles for enemy and adds currency to the player. Then destroys the particles and the enemy object.
    void KillEnemy()
    {
        confirmDeath = true;
        GameObject deathEffect = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        WaveSpawnerScript.enemyCounter--;
        Destroy(deathEffect, 5f);
        PlayerInfoScript.currency += killReward;
        Destroy(gameObject);
    }
}
