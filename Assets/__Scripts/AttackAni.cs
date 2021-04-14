using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAni : MonoBehaviour
{
    //gets animation sprite
    Animator anim;
    float nextAni = 0f;

    void Start()
    {
        //instantiate game object
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        //every frame check to see if you player has attacked
        if (Time.time >= nextAni)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // on space press
            {
                anim.SetTrigger("Attack"); //call animation trigger
                nextAni = Time.time + 1f; //at animation delay
            }
        }       
    }
}
