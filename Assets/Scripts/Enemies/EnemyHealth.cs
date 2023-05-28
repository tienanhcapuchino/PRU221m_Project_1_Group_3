using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 5;
    public Transform healthBar;
    private float originHealthBarWidth;

    private void Start()
    {
        health = maxHealth;
        originHealthBarWidth = healthBar.localScale.x;
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void UpdateHealthBar()
    {
        float healthBarWidth = originHealthBarWidth * health / maxHealth;
        healthBar.localScale = new Vector2(healthBarWidth, healthBar.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("okokok");
        TakeHit(1);
    }
}
