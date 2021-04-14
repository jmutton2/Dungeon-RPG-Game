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

    float nextDash = 0f;
    float dashGo = 5f;

    void Start()
    {
        GlobalVarStore.Dash = 5;
    }
    void Update()
    { //gets raw movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //setting float values from raw movement into blend tree
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //getting float values from blend tree
        currentDirx = animator.GetFloat("Horizontal");
        currentDiry = animator.GetFloat("Vertical");

        //projectile shoot
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.K)) // on key press 'K'
            {
                if(currentDirx == -1) //shoot left
                {
                    direction = 3;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDirx == 1) //shoot right
                {
                    direction = 2;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDiry == 1) //shoot down
                {
                    direction = 1;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if (currentDiry == -1) //shoot up
                {
                    direction = 0;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                } else if(currentDiry == 0 && currentDirx == 0) //default case
                {
                    direction = 0;
                    ProjFire();
                    nextAttackTime = Time.time + attackDelay;
                }
            }
        }
        
        //projectile foot function
        void ProjFire()
        {

            //instantiate projectile depending on direction player is facing
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
        //allows player to dash by pressing 'L'
        if (Time.time >= nextDash && GlobalVarStore.Dash > 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine(Dash()); //call dash function
                nextDash = Time.time + dashGo; //set delay for dash
            }
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
   IEnumerator Dash() //dash function
   {
        GlobalVarStore.Dash = GlobalVarStore.Dash - 1; //remove number of dashes left from global variable
        moveSpeed = 30; // update speed
        yield return new WaitForSeconds(0.5f); //wait half a second
        moveSpeed = 10; // default speed
   }


}


