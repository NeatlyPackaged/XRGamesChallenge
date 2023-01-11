using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = respawnPoint.position;
        }
    }
}
