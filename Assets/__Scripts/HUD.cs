using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject soulCounter;
    string coins = GlobalVarStore.Coins.ToString();


    void Update()
    {
        Text text = soulCounter.GetComponent<Text>();
        text.text = "Souls: " + coins;
    }

}
