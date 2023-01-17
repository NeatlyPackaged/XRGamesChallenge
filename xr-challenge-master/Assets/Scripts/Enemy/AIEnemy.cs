using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class AIEnemy : MonoBehaviour
{
    [Header("NavMeshAgent Link")]
    public NavMeshAgent agent;

    [Header("AI Stats")]
    [Range(0, 100)] public float speed;
    [Range (1, 500)] public float walkRadius;

    // On start, the enemy will grab a NavmeshAgent and will set the stats of the AI to the stats above, this will also set the destination of the AI to be random
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent != null)
        {
            agent.speed = speed;
            agent.destination = RandomNavMeshLocation();
        }
    }

    // This will set the players next location to be random every time it reached its location before
    public void Update()
    {
        if(agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.destination = RandomNavMeshLocation();
        }
    }

    // This will find a random location around the map
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

}
