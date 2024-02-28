using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info")]
public class SOInfo : ScriptableObject
{
    [SerializeField] private List<QuimikInfo> _infoList = new List<QuimikInfo>();
    [SerializeField] private List<Elementos> _elementos = new List<Elementos>();
    [SerializeField] private List<Habitats> _habitats = new List<Habitats>();

    [Serializable]
    public class QuimikInfo
    {
        public int numero;
        public int elemento1;
        public int elemento2;
        public string nombre;
        public float altura;
        public float peso;
        public string descripcion;
    }

    [Serializable]
    public class Elementos
    {
        public int num_elemento;
        public string tipo;
    }

    [Serializable]
    public class Habitats
    {
        public int id_habitat;
        public string nombre;
    }
}
