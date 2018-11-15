using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public static class XMLPersona { 
    
    public static void Guardar(Persona persona)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/persona.xml", FileMode.Create);

        PersonaData data = new PersonaData(persona);
        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int[] CargarPersona(){
        if(File.Exists(Application.persistentDataPath + "/persona.xml"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/persona.xml", FileMode.Open);

            PersonaData data = bf.Deserialize(stream) as PersonaData;
            stream.Close();
            return data.stats;

        }
        else
        {
            Debug.LogError("Archivo no existe");
            return new int[4];
        }
    }
 }

[Serializable]
public class PersonaData
{
    public int[] stats;

    public PersonaData(Persona per)
    {
        stats = new int[4];
        stats[0] = per.edad;
        stats[1] = per.tiempo;
        stats[2] = per.damage;
        stats[3] = per.nivel;
    }
}
