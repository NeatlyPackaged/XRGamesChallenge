using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    public AIEnemy AI_Instance;
    public ChaseEnemy Tracker_Instance;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        AI_Instance = GetComponent<AIEnemy>();
        Tracker_Instance = GetComponent<ChaseEnemy>();
    }

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

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

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
