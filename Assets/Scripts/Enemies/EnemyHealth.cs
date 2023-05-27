using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 5;
    public HealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetHealth(health, maxHealth);
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth); 

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
