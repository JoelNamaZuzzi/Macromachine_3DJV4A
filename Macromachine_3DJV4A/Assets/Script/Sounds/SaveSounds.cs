using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSounds
{
    public static void SaveSoundParam(SoundManager SM)
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/sounds.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        SoundsData data = new SoundsData(SM);
        
        formater.Serialize(stream, data);
        stream.Close();
    }

    public static SoundsData LoadSound()
    {
        string path = Application.persistentDataPath + "/sounds.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SoundsData Data = formatter.Deserialize(stream) as SoundsData;
            stream.Close();
            return Data;
        }
        else
        {
            Debug.LogError("Config File Not Found at "+path);
            return null;
        }
    }
}
