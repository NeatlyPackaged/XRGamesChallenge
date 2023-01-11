using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{


    public GameObject TitleScreen;

    public GameObject Menu1;

    public GameObject Menu2;

    public AudioSource sound;

    public AudioMixer _audioMixer;

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;

    void Start()
    {

        Menu2.SetActive(false);


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
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

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}

    
