using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //instantiate gameobject
    public GameObject soulCounter;
    private Text text1;
    private Text text18;
    public GameObject health;
    public GameObject attackDamage;
    public GameObject attackSpeed;
    public GameObject projSpeed;
    public GameObject dash;
    

    void Start()
    {
        //text components
        text1 = soulCounter.GetComponent<Text>();
        text18 = dash.GetComponent<Text>();

        //setting hud stats for default character
        if (GlobalVarStore.Equipped == "default")
        {
            Text text2 = health.GetComponent<Text>();
            text2.text = "Max Health: 200";

            Text text3 = attackDamage.GetComponent<Text>();
            text3.text = "Attack Damage: 50";

            Text text4 = attackSpeed.GetComponent<Text>();
            text4.text = "Attack Speed: 1x";

            Text text5 = projSpeed.GetComponent<Text>();
            text5.text = "Projectile Speed: 15";
        }
        //setting hud stats for fire character
        if (GlobalVarStore.Equipped == "fire")
        {
            Text text6 = health.GetComponent<Text>();
            text6.text = "Max Health: 150";

            Text text7 = attackDamage.GetComponent<Text>();
            text7.text = "Attack Damage: 60";

            Text text8 = attackSpeed.GetComponent<Text>();
            text8.text = "Attack Speed: 1x";

            Text text9 = projSpeed.GetComponent<Text>();
            text9.text = "Projectile Speed: 20";
        }
        //setting hud stats for ice character
        if (GlobalVarStore.Equipped == "ice")
        {
            Text text10 = health.GetComponent<Text>();
            text10.text = "Max Health: 300";

            Text text11 = attackDamage.GetComponent<Text>();
            text11.text = "Attack Damage: 25";

            Text text12 = attackSpeed.GetComponent<Text>();
            text12.text = "Attack Speed: 1x";

            Text text13 = projSpeed.GetComponent<Text>();
            text13.text = "Projectile Speed: 20";
        }
        //setting hud stats for lightning character
        if (GlobalVarStore.Equipped == "lightning")
        {
            Text text14 = health.GetComponent<Text>();
            text14.text = "Max Health: 200";

            Text text15 = attackDamage.GetComponent<Text>();
            text15.text = "Attack Damage: 20";

            Text text16 = attackSpeed.GetComponent<Text>();
            text16.text = "Attack Speed: 2x";

            Text text17 = projSpeed.GetComponent<Text>();
            text17.text = "Projectile Speed: 20";
        }
    }

    void Update()
    { //updates loot and dash varibles on HUD
        string coins = GlobalVarStore.Coins.ToString();
        text1.text = "Loot: " + coins;

        string dashes = GlobalVarStore.Dash.ToString();
        text18.text = "Dashes: " + dashes;

    }

}
