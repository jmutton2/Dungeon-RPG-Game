using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTouch : MonoBehaviour
{
    //boss health variables
    public int maxHealth = 500;
    public int currentHealth = 500;
    public HealthBar healthbar;

    public GameObject deathDrop;
    public GameObject coinDrop;


    private void Start()
    {
        currentHealth = maxHealth; //set boss max health
        //healthbar.SetMaxHeath(maxHealth);
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
    public void TakeDamage(int damage) //damage boss
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die() //destroy boss
    {
        Instantiate(deathDrop, this.transform.position, transform.rotation);
        Instantiate(coinDrop, this.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
