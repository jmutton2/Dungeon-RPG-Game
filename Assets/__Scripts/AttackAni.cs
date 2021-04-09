﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAni : MonoBehaviour
{
    Animator anim;
    float nextAni = 0f;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextAni)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(GlobalVarStore.Coins);
                anim.SetTrigger("Attack");
                nextAni = Time.time + 1f;
            }
        }
        
    }
}