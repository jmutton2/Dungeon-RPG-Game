using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    public SpriteRenderer SR;

    void Start()
    {

        GameObject player = GameObject.Find("Player 1");
        GameObject player2 = GameObject.Find("ColliderRegistry");

        PlayerAttack attack = player.GetComponent<PlayerAttack>();
        PlayerMovement shoot = player.GetComponent<PlayerMovement>();
        EnemyTouch health = player2.GetComponent<EnemyTouch>();


        switch (GlobalVarStore.Equipped)
        {
            case "default":
                SR.color = Color.white;
                attack.attackDamage = 35;
                shoot.projectileSpeed = 15;
                health.maxHealth = 200;
                health.currentHealth = 200;
                GlobalVarStore.ProjDamage = 40;
                GlobalVarStore.AttackDelay = 1f;
                break;
            case "fire":
                SR.color = Color.red;
                attack.attackDamage = 50;
                shoot.projectileSpeed = 20;
                health.maxHealth = 300;
                health.currentHealth = 300;
                GlobalVarStore.ProjDamage = 20;
                GlobalVarStore.AttackDelay = 1f;
                break;
            case "ice":
                SR.color = Color.cyan;
                attack.attackDamage = 20;
                shoot.projectileSpeed = 20;
                health.maxHealth = 300;
                health.currentHealth = 300;
                GlobalVarStore.ProjDamage = 10;
                GlobalVarStore.AttackDelay = 1f;
                break;
            case "lightning":
                SR.color = Color.yellow;
                attack.attackDamage = 55;
                shoot.projectileSpeed = 20;
                health.maxHealth = 300;
                health.currentHealth = 300;
                GlobalVarStore.ProjDamage = 50;
                GlobalVarStore.AttackDelay = 1f;
                break;
        }
    }
}
