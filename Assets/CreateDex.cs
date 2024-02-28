using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateDex : MonoBehaviour
{
    public SOInfo soInfo;
    public GameObject prefabDex;

    // Start is called before the first frame update
    void Start()
    {
        CreateBichos();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CreateBichos()
    {
        foreach (var bicho in soInfo.infoList)
        {
            GameObject dex = Instantiate(prefabDex,transform);
            var children = dex.GetComponentsInChildren<Transform>();
            foreach (var item in children)
            {
                if (item.name == "Num") item.GetComponent<TMP_Text>().text = bicho.numero.ToString();
                if (item.name == "Nombre") item.GetComponent<TMP_Text>().text = bicho.nombre;
                if (item.name == "Image") item.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/"+bicho.nombre);

            }

        }
    }
}
