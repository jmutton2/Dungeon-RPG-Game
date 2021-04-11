using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BarrelMain : MonoBehaviour
{
    public System.Random box = new System.Random();


    public int maxHealth = 100;
    private int currentHealth;
    public SpriteRenderer SR;
    public double delay = 0;
    private bool hit = false;
    int num;

    public GameObject Drop;

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
        num = box.Next(1,4);

        if(num == 1)
        {
            Instantiate(Drop, this.transform.position, transform.rotation);
        }

        //Instantiate(coinDrop, this.transform.position, transform.rotation);
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
