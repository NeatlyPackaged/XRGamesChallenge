using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [Header("FOV Stats")]
    public float radius;
    [Range(0, 360)]
    public float angle;

    [Header("Config")]
    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    [Header("Either AI scripts to switch to")]
    public AIEnemy AI_Instance;
    public ChaseEnemy Tracker_Instance;

    // The AI will set the ref to player so that it can detect it and will find the scripts components
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        AI_Instance = GetComponent<AIEnemy>();
        Tracker_Instance = GetComponent<ChaseEnemy>();
    }

    // If the enemy can see the player it will begin to enable the chase script and disable the random position AI, the other way around if not
    public void Update()
    {
        if (canSeePlayer)
        {
            AI_Instance.enabled = false;
            Tracker_Instance.enabled = true;
        }
        else
        {
            AI_Instance.enabled = true;
            Tracker_Instance.enabled = false;
        }
            
    }

    // The system here will start the event below
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    // This will create a sphere collision around the player and will try to detect the player that is connected to the target mask, if it can see it, it will begin chasing the player
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
