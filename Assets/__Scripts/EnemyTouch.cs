using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTouch : MonoBehaviour{

    public int maxHealth = 200;
    public int currentHealth = 200;
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
                SceneManager.LoadScene("DeathScreen");
            }

        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        GlobalVarStore.Score = GlobalVarStore.Score - 4;
    }
}
