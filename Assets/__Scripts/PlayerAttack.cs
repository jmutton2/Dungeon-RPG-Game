﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask layers;
    public int attackDamage = 40;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                //CheckBarrelHit();
                nextAttackTime = Time.time + 1f;
            }
        }
        
    }

    void Attack()
    {

        LayerMask enemy = LayerMask.GetMask("Enemy");
        LayerMask barrel = LayerMask.GetMask("Barrel");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
        Collider2D[] hitBarrel = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, barrel);

        foreach (Collider2D hit in hitEnemy)
        {
            hit.GetComponent<EnemyMain>().TakeDamage(attackDamage);
        }

        foreach (Collider2D hit in hitBarrel)
        {
            hit.GetComponent<BarrelMain>().TakeDamage(attackDamage);

        }
    }


    void OnDrawGizmosSelected()
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
