using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    [Header("NavMesh Link")]
    public NavMeshAgent agent;

    [Header("AI Stats")]
    [Range(0, 100)] public float speed;

    [Header("Player Link")]
    Transform player;

    // On start the AI will link the navmesh stats with the stats above and will track the players location
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (agent != null)
        {
            agent.speed = speed;
            agent.destination = player.position;
        }
    }

    // The AI will forever chase the players position
    public void Update()
    {
        agent.destination = player.position;
    }
}
