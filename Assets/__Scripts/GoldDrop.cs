using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GlobalVarStore.Coins = GlobalVarStore.Coins + 10;
            GlobalVarStore.Score = GlobalVarStore.Score + 20;
        }
    }
}
