using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePhoto : MonoBehaviour
{
    public Image iconImage;
    public Image destinationImage;

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
}
