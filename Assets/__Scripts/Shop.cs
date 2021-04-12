using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject lootScore;
    private Text text;

    void Start()
    {
        text = lootScore.GetComponent<Text>();
    }
    void Update()
    {
        string coins = GlobalVarStore.Coins.ToString();
        text.text = "Loot: " + coins;
    }



    //Purchase buttons
    public void DefaultButton()
    {

        if (!GlobalVarStore.DefaultPurchased && GlobalVarStore.Coins >= 5)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 5;
            GlobalVarStore.DefaultPurchased = true;
            GlobalVarStore.Equipped = "default";
        }

        if (GlobalVarStore.DefaultPurchased)
        {
            GlobalVarStore.Equipped = "default";
        }


    }

    public void FireButton()
    {

        if (!GlobalVarStore.FirePurchased && GlobalVarStore.Coins >= 50)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.FirePurchased = true;
            GlobalVarStore.Equipped = "fire";
        }

        if (GlobalVarStore.FirePurchased)
        {
            GlobalVarStore.Equipped = "fire";
        }

    }

    public void IceButton()
    {

        if (!GlobalVarStore.IcePurchased && GlobalVarStore.Coins >= 50)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.IcePurchased = true;
            GlobalVarStore.Equipped = "ice";
        }

        if (GlobalVarStore.IcePurchased)
        {
            GlobalVarStore.Equipped = "ice";
        }
    }

    public void LightningButton()
    {

        if (!GlobalVarStore.LightningPurchased && GlobalVarStore.Coins >= 100)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 100;
            GlobalVarStore.LightningPurchased = true;
            GlobalVarStore.Equipped = "lightning";
        }

        if (GlobalVarStore.LightningPurchased)
        {
            GlobalVarStore.Equipped = "lightning";
        }
    }


    //Back button 
    public void SceneSwap()
    {
        SceneManager.LoadScene("ShopMain");
    }
}
