using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject player;
    public GameObject toPoint;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(toPoint.transform.position.x - 4, toPoint.transform.position.y, 0);
        }
    }

}

