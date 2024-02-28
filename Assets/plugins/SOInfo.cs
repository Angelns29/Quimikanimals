using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info")]
public class SOInfo : ScriptableObject
{
    [SerializeField] public List<QuimikInfo> infoList = new List<QuimikInfo>();
    [SerializeField] public List<Elementos> elementos = new List<Elementos>();
    [SerializeField] public List<Habitats> habitats = new List<Habitats>();

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
        public QuimikInfo(int num, int elem1, int elem2, string nombre, float altura, float peso, string desc)
        {
            this.numero = num;
            this.elemento1 = elem1;
            this.elemento2 = elem2;
            this.nombre = nombre;
            this.altura = altura;
            this.peso = peso;
            this.descripcion = desc;
        }
    }
    

    [Serializable]
    public class Elementos
    {
        public int num_elemento;
        public string tipo;
        public Elementos(int num_elemento, string tipo)
        {
            this.num_elemento = num_elemento;
            this.tipo = tipo;
        }
    }

    [Serializable]
    public class Habitats
    {
        public int id_habitat;
        public string nombre;
        public Habitats(int id_habitat, string nombre)
        {
            this.id_habitat = id_habitat;
            this.nombre = nombre;
        }
    }
}
