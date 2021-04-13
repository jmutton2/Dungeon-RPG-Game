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

    public GameObject projectilePrefab;
    public float projectileSpeed = 15;
    public float projectileDropTime = 2f;
    int projCounter = 0;
    bool yes = true;

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

            if (yes)
            {
                StartCoroutine(ProjectileDelay());
                yes = false;
            }

        }


        if (GlobalVarStore.Equipped == "ice")
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
    public void ProjectileFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();
        projGO.transform.position = transform.position;

        Destroy(projGO, 15);

    }
    IEnumerator ProjectileDelay()
    {
        ProjectileFire();
        while (projCounter < 5)
        {
            ProjectileFire();
            projCounter++;
            yield return new WaitForSeconds(2.0f);

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
        Debug.Log("Enemy died!");
    }
}
