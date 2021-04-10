using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem 
{
    public static void SaveScene(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.data"+SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);
        
        SceneData data = new SceneData(gameManager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static SceneData LoadScene()
    {
        string path = Application.persistentDataPath + "/scene.data"+SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream  = new FileStream(path, FileMode.Open);
            
            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();
            
            return data;

        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
        
    }
}
