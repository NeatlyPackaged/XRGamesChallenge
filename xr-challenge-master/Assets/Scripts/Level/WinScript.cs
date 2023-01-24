using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [Header("Win Config")]
    public BoxCollider winBox;
    public ParticleSystem winParticles;
    public AudioSource winFanfare;
    public GameObject winText;
    public Animator animator;

    // On Start, the text will not appear and the collision to win will be disabled
    private void Start()
    {
        winText.SetActive(false);
        winBox.enabled = false;
    }

    //If the bool to is win has been set true in the door system, it will enable the collision
    void Update()
    {
        if (DoorSystem.isWin)
            winBox.enabled = true;
    }

    //If the player touches the collision, it will start the event to win the game
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(WinGame());
        }
    }

    //This will win the game by calling the text,audio and particle before loading the scene after some time has passed
    IEnumerator WinGame()
    {
        winText.SetActive(true);
        animator.SetTrigger("WinGame");
        winFanfare.Play();
        winParticles.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Win");
    }


}

