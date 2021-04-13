using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTouch : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth = 500;
    public HealthBar healthbar;

    public GameObject deathDrop;
    public GameObject coinDrop;


    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHeath(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BossProj")
        {
            Debug.Log("Hit detected");
            TakeDamage(30);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {

        Instantiate(deathDrop, this.transform.position, transform.rotation);
        Instantiate(coinDrop, this.transform.position, transform.rotation);

        Destroy(gameObject);
        Debug.Log("Boss died!");
    }
}
