﻿using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //Purchase buttons
    public void DefaultButton()
    {
        if (!GlobalVarStore.DefaultPurchased)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 5;
            GlobalVarStore.DefaultPurchased = true;
        }
        GlobalVarStore.Equipped = "default";
    }

    public void FireButton()
    {
        if (!GlobalVarStore.FirePurchased)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.FirePurchased = true;
        }
        GlobalVarStore.Equipped = "fire";
    }

    public void IceButton()
    {
        if (!GlobalVarStore.IcePurchased)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.IcePurchased = true;
        }
        GlobalVarStore.Equipped = "ice";
    }

    public void LightningButton()
    {
        if (!GlobalVarStore.LightningPurchased)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.LightningPurchased = true;
        }
        GlobalVarStore.Equipped = "lightning";
    }


    //Back button 
    public void SceneSwap()
    {
        SceneManager.LoadScene("ShopMain");
    }
}