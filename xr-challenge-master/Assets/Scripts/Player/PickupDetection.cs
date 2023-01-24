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


    // On colliding with the star, the star collected variable will increment to allow future scripts to work
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Star")
        {
            StartCoroutine(IncrementPoint());
        }
    }

    // Increments the collected stars and updates the UI to show the score
    IEnumerator IncrementPoint()
    {
        collectedStars++;
        scoreCollected = scoreCollected + _Pickups.ScoreValue;
        //Debug.Log(_Pickups.GetPickedUp().ToString());
        yield return new WaitForSeconds(2);
    }

}
