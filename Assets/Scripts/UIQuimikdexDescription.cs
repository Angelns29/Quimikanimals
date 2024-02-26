using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIQuimikdexDescription : MonoBehaviour
{

    [Header("Start Menu")]
    public GameObject descriptionMenu;
    public GameObject mapMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToDescription()
    {
        mapMenu.SetActive(false);
        descriptionMenu.SetActive(true);
    }
    public void GoToMap()
    {
        descriptionMenu.SetActive(false);
        mapMenu.SetActive(true);
    }
    public void ReturnToDex()
    {
        SceneManager.LoadScene(0);
    }
}
