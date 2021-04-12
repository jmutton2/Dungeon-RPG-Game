using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PrefabUtility.InstantiatePrefab.

public class EnemyMain : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float speed = 8;
    public float distance = 15;
    public int shootDamage = 50;
    public SpriteRenderer SR;
    private Transform target;

    public double delay = 0;
    float freezeDelay = 0;
    private bool hit = false;


    public int dropRate;

    public GameObject deathDrop;
    public GameObject coinDrop;

    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float distanceCurrent = Vector3.Distance(target.transform.position, this.transform.position);

        if (distanceCurrent <= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        
        if(GlobalVarStore.Equipped == "ice")
        {
            if(freezeDelay > Time.time && hit == true)
            {
                SR.color = Color.blue;
                speed = 0;
                hit = false;
            }
            if (freezeDelay < Time.time)
            {
                SR.color = Color.white;
                speed = 8;
            }
        }

        else
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

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "ProjHero")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy HIT");
            TakeDamage(GlobalVarStore.ProjDamage);
            if (currentHealth <= 0)
            {
                Destroy(transform.parent.gameObject);
                
            }

        }
    }
    public void TakeDamage(int damage)
    {

        //if(GlobalVarStore.Equipped == "fire")
        //{
        //    hit = true;
        //    delay = Time.time + 0.5;
        //    int wait = 0;
        //    int waited = 1;
            
        //    while(wait < waited && done == false)
        //    {
        //        if(done == false)
        //        {
        //            currentHealth -= damage;
        //            fireTick = Time.time + 1;
        //            done = true;
        //        }      

        //    }
        //}
        //else
        //{
            hit = true;
            delay = Time.time + 0.5;
            freezeDelay = Time.time + 2;
            currentHealth -= damage;
        //}   

        if (currentHealth <= 0)
        {
            Die();
        }
  
    }

    void Die()
    {
        //Dead body spawn
        Instantiate(deathDrop, this.transform.position, transform.rotation);

        //Coin spawn
        for (float i = 1; i <= dropRate; i++)
        {
            Instantiate(coinDrop, this.transform.position, transform.rotation);
        }
        
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
