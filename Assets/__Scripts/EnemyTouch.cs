using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTouch : MonoBehaviour{

    //health variables
    public int maxHealth = 200;
    public int currentHealth = 200;
    public HealthBar healthbar;


    private void Start()
    {
        currentHealth = maxHealth; //set default health
        healthbar.SetMaxHeath(maxHealth); //update health bar
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") //collision with first enemy
        {
            TakeDamage(20);
            if(currentHealth <= 0)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }
        if (other.gameObject.tag == "Boss") //collision with final boss
        {
            TakeDamage(50);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }
        if (other.gameObject.tag == "BossProj") //collision with final boss projectile
        {
            TakeDamage(30);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }
        if (other.gameObject.tag == "ProjEnemy") //collision with second enemy projectile
        {
            TakeDamage(70); 
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("DeathScreen");
            }
        }
    }

    void TakeDamage(int damage) //damage player function
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        GlobalVarStore.Score = GlobalVarStore.Score - 4;
    }
}
