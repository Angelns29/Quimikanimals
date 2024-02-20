using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Start Menu")]
    public GameObject startMenu;
    public GameObject dexMenu;
    public GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
