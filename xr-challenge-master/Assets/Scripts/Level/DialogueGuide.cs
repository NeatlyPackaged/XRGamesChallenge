using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueGuide : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;
    public string popUp;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("PopUp");
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PopUp(popUp);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("close");
        }
    }
}
