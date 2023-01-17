using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueGuide : MonoBehaviour
{
    [Header("Config")]
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    [Header("The Text to display")]
    public string popUp;

    // This will activate the text and display the text to what you set it to
    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("PopUp");
    }

    // When you collide with the box, it will begin to call the event to pop the text up with the string you make in the editor
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PopUp(popUp);
        }
    }

    // When you leave the collision, the pop up will disable
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("close");
        }
    }
}
