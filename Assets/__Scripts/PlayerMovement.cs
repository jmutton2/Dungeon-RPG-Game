using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 80f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    public GameObject projectilePrefab;
    public float projectileSpeed = 15;
    float nextAttackTime = 0f;
    public float lifespan = 2f;
    public float attackDelay = 1f;
    private int direction;
    private float currentDirx;
    // -1 => left, +1 => right
    private float currentDiry;
    // -1 => down, +1 => up


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        currentDirx = animator.GetFloat("Horizontal");
        currentDiry = animator.GetFloat("Vertical");


        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if(currentDirx == -1)
                {
                    direction = 3;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDirx == 1)
                {
                    direction = 2;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDiry == 1)
                {
                    direction = 1;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if (currentDiry == -1)
                {
                    direction = 0;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDiry == 0 && currentDirx == 0)
                {
                    direction = 0;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                }
            }
        }
        

        void ProjFire()
        {
            GameObject projGO = Instantiate<GameObject>(projectilePrefab);
            Rigidbody2D rigidB = projGO.GetComponent<Rigidbody2D>();

            projGO.transform.position = transform.position;

            if(direction == 1)
            {
                rigidB.velocity = Vector3.up * projectileSpeed;
                Destroy(projGO, lifespan);
            }
            else if (direction ==2)
            {
                rigidB.velocity = Vector3.right * projectileSpeed;
                Destroy(projGO, lifespan);
            }
            else if(direction == 3)
            {
                rigidB.velocity = Vector3.left * projectileSpeed;
                Destroy(projGO, lifespan);
            }
            else
            {
                rigidB.velocity = Vector3.down * projectileSpeed;
                Destroy(projGO, lifespan);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}


