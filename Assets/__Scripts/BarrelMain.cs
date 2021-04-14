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
        currentHealth = maxHealth; //set barrel health
    }

    void Update()
    {

        num = box.Next(1, 3); //get random number for gold drop from barrel

        if (delay > Time.time && hit == true) //turn red on hit and back to normal
        {
            SR.color = Color.red;
            hit = false;
        }
        if (delay < Time.time)
        {
            SR.color = Color.white;
        }
    }

    public void TakeDamage(int damage) //deal damage to barrel
    {
        hit = true;
        delay = Time.time + 0.5;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() //destroy barrel
    {
       
        if(num == 1)
        {
            Instantiate(Drop, this.transform.position, transform.rotation);
        }

        GlobalVarStore.Score = GlobalVarStore.Score + 5;

        Destroy(gameObject);

    }
}
