using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject player;
    public GameObject toPoint;

    public void Start()
    {
        GlobalVarStore.NextTeleTime = 5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time >= GlobalVarStore.NextTeleTime)
        {
                if (other.gameObject.tag == "Player")
                {
                    player.transform.position = new Vector3(toPoint.transform.position.x, toPoint.transform.position.y, 0);
                    GlobalVarStore.NextTeleTime  = GlobalVarStore.NextTeleTime  + 5f;
                }
        }

    }
}

