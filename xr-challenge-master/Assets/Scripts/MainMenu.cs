using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioSource sound;

    public void AudioPlay()
    {
        sound.Play();
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        StartCoroutine(CloseGame());
    }

    IEnumerator CloseGame()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        Application.Quit();
    }

}

    
