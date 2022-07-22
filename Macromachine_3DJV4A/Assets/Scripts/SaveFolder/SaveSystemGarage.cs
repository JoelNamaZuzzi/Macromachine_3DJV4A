using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystemGarage
{
    public static void SaveGarage(GarageUIScript garage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/garage.car";
        FileStream stream = new FileStream(path, FileMode.Create);

        GarageData data = new GarageData(garage);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static GarageData LoadGarage(GarageUIScript garage)
    {
        string path = Application.persistentDataPath + "/garage.car";
        if (File.Exists(path))
        {
            Debug.Log("Load");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            GarageData data = formatter.Deserialize(stream) as GarageData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Fichier de sauvegarde introuvable " + path);
            return null;
        }
    }
}
