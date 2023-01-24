using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("MenuObjects")]
    public GameObject TitleScreen;
    public GameObject Menu1;
    public GameObject Menu2;

    [Header("Menu Config")]
    public AudioSource sound;
    public AudioMixer _audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    // On Start, the options menu will be disabled, and the resolutions for the dropdown will be calculated based off of your monitors display and will give option to refresh rate when the player wants to pick a hz
    void Start()
    {

        Menu2.SetActive(false);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void ClearResolutions()
    {
        resolutionDropdown.ClearOptions();
    }

    // Every time this is called it will play a sound that i choose in the editor
    public void AudioPlay()
    {
        sound.Play();
    }

    // This will play the event to start the game
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

    public void StartTutorial()
    {
        StartCoroutine(LoadTutorial());
    }

    IEnumerator LoadTutorial()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Tutorial");
    }

    // This will play the event to go back to the menu
    public void BackToMenu()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("MainMenu");
    }

    // This will play the event to Quit the game
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

    // This will play the event to show the options menu
    public void OpenOptions()
    {
        StartCoroutine(OptionsMenu());
    }

    IEnumerator OptionsMenu()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        TitleScreen.SetActive(false);
        Menu1.SetActive(false);
        Menu2.SetActive(true);
    }

    // This will play the event to hide the options menu
    public void BackMenu()
    {
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        AudioPlay();
        yield return new WaitForSeconds(1.2f);
        TitleScreen.SetActive(true);
        Menu1.SetActive(true);
        Menu2.SetActive(false);
    }

    // This will Set the resolution to what you select on the dropdown menu
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

    // This will set the volume based on the slider
    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }

    // This will set the quality that is made in the project settings
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // This will make your game full Screen or not
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}

    
