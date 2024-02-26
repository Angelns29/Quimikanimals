using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Start Menu")]
    public GameObject startMenu;
    public GameObject dexMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;

    [Header("Start Menu")]
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = musicSource.volume;
        sfxSlider.value = sfxSource.volume;
    }

    public void GoToDex()
    {
        startMenu.SetActive(false);
        dexMenu.SetActive(true);
    }
    public void GoToSettings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ReturnToStart()
    {
        if (settingsMenu.activeInHierarchy == true) settingsMenu.SetActive(false);
        else if (dexMenu.activeInHierarchy == true) dexMenu.SetActive(false); 
        startMenu.SetActive(true);
    }
    public void SeeDescription()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToDex()
    {
        SceneManager.LoadScene(0);
        if(dexMenu.activeInHierarchy == false)dexMenu.SetActive(true);
    }

    public void ShowCredits()
    {
        creditsMenu.SetActive(true);
    }
    public void HideCreadits()
    {
        creditsMenu?.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetVolumeSounds(float volume)
    {
        sfxSource.volume = volume;
    }
}
