using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    public Image iconImage;
    public Image destinationImage;
    public GameObject numGO;

    // Start is called before the first frame update
    void Start()
    {
        iconImage = GetComponent<Image>();
        destinationImage = GameObject.FindGameObjectWithTag("PhotoImg").GetComponent<Image>();

    }

    public void SetImage()
    {
        destinationImage.sprite = iconImage.sprite;
    }

    public void SeeDescription()
    {
        PlayerPrefs.SetInt("Bicho", Int32.Parse(numGO.GetComponent<TMP_Text>().text));
        Debug.Log(PlayerPrefs.GetInt("Bicho"));
        SceneManager.LoadScene(1);
    }
}
