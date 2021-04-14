using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //attack variables
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask layers;
    public int attackDamage = 35;
    float nextAttackTime = 0f;
    public float attackDelay = 1f;


    void Update()
    {//player melee attack
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))//activate on 'space' press
            {
                Attack(); //call attack fucntions
                nextAttackTime = Time.time + attackDelay; // add delay
            }
        }
    }

    void Attack()
    {

        LayerMask enemy = LayerMask.GetMask("Enemy");
        LayerMask barrel = LayerMask.GetMask("Barrel");
        LayerMask boss = LayerMask.GetMask("Boss"); // Andy added boss layer


        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
        Collider2D[] hitBarrel = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, barrel);
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, boss); // Andy added boss collider

        foreach (Collider2D hit in hitEnemy) //checking layermask for enemies
        {
            hit.GetComponent<EnemyMain>().TakeDamage(attackDamage);
        }

        foreach (Collider2D hit in hitBarrel) //checking layermask for barrels
        {
            hit.GetComponent<BarrelMain>().TakeDamage(attackDamage);
        }

        // Andy added boss collider2d
        foreach (Collider2D hit in hitBoss) //checking layermask for boss
        {
            hit.GetComponent<BossMain>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() //drawing sphere for testing purposes.
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
