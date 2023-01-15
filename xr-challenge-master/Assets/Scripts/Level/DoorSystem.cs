using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public BoxCollider Collecter;

    public PickupDetection _StarDoor;

    public GameObject DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        Collecter.enabled = false;
        DialogueBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(_StarDoor.collectedStars == 5)
        {
            DialogueBox.SetActive(false);
            Collecter.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("DoorOpened");
            
            Destroy(this.gameObject);
        }
    }
}
