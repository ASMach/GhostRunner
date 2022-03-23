using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public void SaveRun(Save save)
    {
        //string json = JsonUtility.ToJson(save); // TODO: Implement full JSON saving system
        
        BinaryFormatter bf = new BinaryFormatter();
        // Create a new save file for each level to store its run data
        FileStream file = File.Create(Application.persistentDataPath + "/" + save.level + "gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }

    public Save LoadRunData(string level)
    {
		string filePath = Application.persistentDataPath + "/" + level + "gamesave.save";

		if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game Loaded");
            return save;
        }
        else
        {
            Debug.Log("No game saved!");
            return null;
        }
    }
}
