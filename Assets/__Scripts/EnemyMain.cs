using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PrefabUtility.InstantiatePrefab.

public class EnemyMain : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float speed;
    public float distance = 15;
    public SpriteRenderer SR;
    private Transform target;

    public double delay = 0;
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
        
        if(delay > Time.time && hit == true)
        {
            SR.color = Color.red;
            hit = false;
        }
        if(delay < Time.time)
        {
            SR.color = Color.white;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "ProjHero")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy HIT");
            TakeDamage(50);
            if (currentHealth <= 0)
            {
                Destroy(transform.parent.gameObject);
                
            }

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
