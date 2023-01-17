using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRespawn : MonoBehaviour
{
    [Header("Transform Ref")]
    [SerializeField]
    public Transform respawnPoint;

    // On collision, player will move to respawn point
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = respawnPoint.position;
        }
    }
}
