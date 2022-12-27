using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetection : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    public Pickup _Pickups;

    [Header("Variables")]
    [SerializeField]
    public float collectedStars;

    [SerializeField]
    public float scoreCollected;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            StartCoroutine(IncrementPoint());   
        }
    }

    IEnumerator IncrementPoint()
    {
        collectedStars++;
        scoreCollected = scoreCollected + _Pickups.ScoreValue;
        Debug.Log(_Pickups.GetPickedUp().ToString());
        yield return new WaitForSeconds(2);
    }

}
