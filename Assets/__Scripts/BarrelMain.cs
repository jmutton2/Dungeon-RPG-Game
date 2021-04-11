using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrelMain : MonoBehaviour
{
    //public class Random;


    public int maxHealth = 100;
    private int currentHealth;
    public SpriteRenderer SR;
    public double delay = 0;
    private bool hit = false;

    public GameObject coinDrop;

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
        Random box = new Random();

        //int num = Random.range


        Instantiate(coinDrop, this.transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
