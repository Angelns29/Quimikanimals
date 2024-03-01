using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIQuimikdexDescription : MonoBehaviour
{

    [Header("Start Menu")]
    public GameObject descriptionMenu;
    public GameObject mapMenu;

    [Header("Info")]
    public SOInfo soInfo;
    public TMP_Text nameText;
    public TMP_Text heightText;
    public TMP_Text weightText;
    public TMP_Text descriptionText;
    public RawImage model3D;
    private SoundManagerScript _soundManager;
    List<GameObject> elements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = SoundManagerScript.instance;
        SetInformation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInformation()
    {
        int numeroBicho = PlayerPrefs.GetInt("Bicho");
        foreach (var bicho in soInfo.infoList)
        {
            if (bicho.numero == numeroBicho)
            {
                nameText.text = bicho.nombre;
                heightText.text = bicho.altura.ToString();
                weightText.text = bicho.peso.ToString();
                descriptionText.text = bicho.descripcion;
                model3D.texture = (Texture)Resources.Load("Modelos/" + bicho.nombre);
                foreach (var item in elements)
                {
                    if (item.name == bicho.elemento1.ToString())
                    {
                        item.SetActive(true);
                    }
                }
            }
        }
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
        PlayerPrefs.SetInt("Bicho", 0);
        SceneManager.LoadScene(0);
    }
    public void PlaySound()
    {
        _soundManager.PlaySFX(nameText.text);
    }
}
