using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed;
    public float distance = 15;
    public SpriteRenderer SR;
    private Transform target;

    public double delay = 0;
    public bool hit = false;

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
        Destroy(gameObject);
        Debug.Log("Enemy died!");
    }
}
