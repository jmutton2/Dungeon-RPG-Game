using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouch : MonoBehaviour{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;


    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHeath(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit detected");
            TakeDamage(20);
            if(currentHealth <= 0)
            {
                Destroy(transform.parent.gameObject);
            }

        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
