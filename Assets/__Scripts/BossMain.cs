using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    // boss stats
    public int maxHealth = 200; // Boss MaxHealth to 200
    private int currentHealth;
    public float speed = 8;
    public float distance = 30; // Boss attack and proj distance to 30
    public int shootDamage = 50;
    public SpriteRenderer SR;
    private Transform target;

    public double delay = 0;
    float freezeDelay = 0;
    private bool hit = false;


    // drop stats
    public int dropRate;

    public GameObject deathDrop;
    public GameObject coinDrop;

    // boss proj stats
    public GameObject BossProjectile;
    float fireRate;
    float nextFire;


    void Start()
    {
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        fireRate = 1f; // set projectile rate 1 proj per 1 sec
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceCurrent = Vector3.Distance(target.transform.position, this.transform.position);

        if (distanceCurrent <= distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // check time for fire
            if(Time.time > nextFire){
                Instantiate(BossProjectile, transform.position, Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
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
            Debug.Log("Boss HIT");
            TakeDamage(GlobalVarStore.ProjDamage);
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
        freezeDelay = Time.time + 2;
        currentHealth -= damage;

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
