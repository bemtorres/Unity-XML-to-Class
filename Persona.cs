using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Persona : MonoBehaviour
{
    public int edad;
    public int tiempo;
    public int damage;
    public int nivel;


    public InputField edadE;
    public InputField tiempoE;
    public InputField damageE;
    public InputField nivelE;
    public Text mensaje;
    public override string ToString()
    {
        string mensaje = String.Format("edad : {0} , tiempo : {1} , daño : {2} , nivel : {3} ", edad, tiempo, damage, nivel);
        return mensaje;
    }

    public void Save()
    {
        this.edad = int.Parse(edadE.text);
        this.tiempo = int.Parse(tiempoE.text);
        this.damage = int.Parse(damageE.text);
        this.nivel = int.Parse(nivelE.text);
        XMLPersona.Guardar(this);
        Load();
    }
    public void Load()
    {
        int[] load = XMLPersona.CargarPersona();

        edad = load[0];
        tiempo = load[1];
        damage = load[2];
        nivel = load[3];

        mensaje.text = this.ToString();
    }

    void Start()
    {
        Debug.Log(Application.persistentDataPath); 
    }

}
