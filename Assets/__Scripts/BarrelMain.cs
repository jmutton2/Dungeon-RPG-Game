using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMain : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;
    public SpriteRenderer SR;
    public double delay = 0;
    private bool hit = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        if (delay > Time.time && hit == true)
        {
            SR.color = Color.red;
            hit = false;
        }
        if (delay < Time.time)
        {
            SR.color = Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        hit = true;
        delay = Time.time + 0.5;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
