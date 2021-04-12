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
        Debug.Log(!GlobalVarStore.DefaultPurchased && GlobalVarStore.Coins >= 5);
        Debug.Log(GlobalVarStore.DefaultPurchased);

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

        Debug.Log(GlobalVarStore.Equipped);

    }

    public void FireButton()
    {
        Debug.Log(!GlobalVarStore.FirePurchased && GlobalVarStore.Coins >= 5);
        Debug.Log(GlobalVarStore.FirePurchased);

        if (!GlobalVarStore.FirePurchased && GlobalVarStore.Coins >= 50)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.FirePurchased = true;
            GlobalVarStore.Equipped = "fire";
        }

        if (GlobalVarStore.DefaultPurchased == true)
        {
            GlobalVarStore.Equipped = "fire";
        }

        Debug.Log(GlobalVarStore.Equipped);
    }

    public void IceButton()
    {
        Debug.Log(!GlobalVarStore.IcePurchased && GlobalVarStore.Coins >= 5);
        Debug.Log(GlobalVarStore.IcePurchased);

        if (!GlobalVarStore.IcePurchased && GlobalVarStore.Coins >= 50)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 50;
            GlobalVarStore.IcePurchased = true;
            GlobalVarStore.Equipped = "ice";
        }
        
        if (GlobalVarStore.DefaultPurchased)
        {
            GlobalVarStore.Equipped = "ice";
        }

        Debug.Log(GlobalVarStore.Equipped);
    }

    public void LightningButton()
    {
        Debug.Log(!GlobalVarStore.LightningPurchased && GlobalVarStore.Coins >= 5);
        Debug.Log(GlobalVarStore.LightningPurchased);

        if (!GlobalVarStore.LightningPurchased && GlobalVarStore.Coins >= 100)
        {
            GlobalVarStore.Coins = GlobalVarStore.Coins - 100;
            GlobalVarStore.LightningPurchased = true;
            GlobalVarStore.Equipped = "lightning";
        }

        if (GlobalVarStore.DefaultPurchased)
        {
            GlobalVarStore.Equipped = "lightning";
        }

        Debug.Log(GlobalVarStore.Equipped);
    }


    //Back button 
    public void SceneSwap()
    {
        SceneManager.LoadScene("ShopMain");
    }
}
