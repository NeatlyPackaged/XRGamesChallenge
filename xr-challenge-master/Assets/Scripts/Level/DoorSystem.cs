using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    [Header("Config")]
    public BoxCollider Collecter;
    public PickupDetection _StarDoor;
    public GameObject DialogueBox;

    [Header("The Bool to be called in the Win Script")]
    public static bool isWin;

    // On Start, the collision to open the door is disabled and the dialogue box enabled
    void Start()
    {
        Collecter.enabled = false;
        DialogueBox.SetActive(true);
    }

    // Once the player has recieved 5 total stars then the dialogue box will disable and the collision enable
    void Update()
    {
        if(_StarDoor.collectedStars == 5)
        {
            DialogueBox.SetActive(false);
            Collecter.enabled = true;
            isWin = true;
        }
    }

    // When you collide with the door, the door will be destroyed // Could change to doing an animation in the future
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("DoorOpened");
            
            Destroy(this.gameObject);
        }
    }
}
