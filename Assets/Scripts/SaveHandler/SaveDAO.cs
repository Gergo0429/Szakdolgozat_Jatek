using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDAO : MonoBehaviour
{
    public Data data;
    private string saveFilePath;

    void Awake()
    {
        saveFilePath = Application.persistentDataPath + "/SaveData.json";
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        if (data.level < 1)
        {
            data.level = 1;
        }
        string saveData = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, saveData);
    }

    public void Load()
    {
        if (File.Exists(saveFilePath))
        {
            string loadData = File.ReadAllText(saveFilePath);
            data = JsonUtility.FromJson<Data>(loadData);
        }
        else
        {
            data = new Data();
            Save();
        }
    }
}
