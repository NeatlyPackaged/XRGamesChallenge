using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Objects")]
    public GameObject PauseUI;

    [Header("Config")]
    public AudioSource sound;

    [Header("Input Fields")]
    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        PauseUI.SetActive(false);
    }

    //these will ensure that the system can detect input or not and will enable or disable the inputs if not detected
    private void OnEnable()
    {
        _playerControls.Player.PauseMenu.started += OpenMenu;
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.PauseMenu.started -= OpenMenu;
        _playerControls.Player.Disable();
    }

    public void OpenMenu(InputAction.CallbackContext obj)
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void AudioPlay()
    {
        sound.Play();
    }

    public void TimeFix()
    {
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        StartCoroutine(Resume());
    }

    IEnumerator Resume()
    {
        AudioPlay();
        TimeFix();
        yield return new WaitForSeconds(.01f);
        PauseUI.SetActive(false);
        
    }
    public void LoadMenu()
    {
        StartCoroutine(GoMenu());
    }

    IEnumerator GoMenu()
    {
        AudioPlay();
        TimeFix();
        yield return new WaitForSeconds(.01f);
        
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    IEnumerator Quit()
    {
        AudioPlay();
        TimeFix();
        yield return new WaitForSeconds(.01f);
        Application.Quit();
       
    }
}
