using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutsideHUD : MonoBehaviour
{
    public GameObject soulCounter;
    string coins = GlobalVarStore.Coins.ToString();

    void Start()
    {
        Text text = soulCounter.GetComponent<Text>();
        text.text = "Souls: " + coins;
    }

}
