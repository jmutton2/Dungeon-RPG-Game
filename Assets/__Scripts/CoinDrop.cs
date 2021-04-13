using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GlobalVarStore.Coins = GlobalVarStore.Coins + 5;
            GlobalVarStore.Score = GlobalVarStore.Score + 10;
        }
    }
}
