using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    public SpriteRenderer SR;

    void Start()
    {
        //instantiate gameobjects
        GameObject player = GameObject.Find("Player 1");
        GameObject player2 = GameObject.Find("ColliderRegistry");
        PlayerAttack attack = player.GetComponent<PlayerAttack>();
        PlayerMovement shoot = player.GetComponent<PlayerMovement>();
        EnemyTouch health = player2.GetComponent<EnemyTouch>();

        //instantiate player's stats depending on what they pick from store
        switch (GlobalVarStore.Equipped)
        {
            case "default": //stats for default character
                SR.color = Color.white;
                attack.attackDamage = 50;
                attack.attackDelay = 1f;
                shoot.projectileSpeed = 15;
                health.maxHealth = 200;
                health.currentHealth = 200;
                GlobalVarStore.ProjDamage = 40;
                break;
            case "fire": //stats for fire character
                SR.color = Color.red;
                attack.attackDamage = 60;
                attack.attackDelay = 1f;
                shoot.projectileSpeed = 20;
                health.maxHealth = 150;
                health.currentHealth = 150;
                GlobalVarStore.ProjDamage = 20;
                break;
            case "ice": //states for ice character
                SR.color = Color.cyan;
                attack.attackDamage = 25;
                attack.attackDelay = 1f;
                shoot.projectileSpeed = 20;
                health.maxHealth = 300;
                health.currentHealth = 300;
                GlobalVarStore.ProjDamage = 10;
                break;
            case "lightning": //states for lightning character
                SR.color = Color.yellow;
                attack.attackDamage = 20;
                attack.attackDelay = 0.5f;
                shoot.projectileSpeed = 20;
                health.maxHealth = 200;
                health.currentHealth = 200;
                GlobalVarStore.ProjDamage = 50;
                break;
        }
    }
}
