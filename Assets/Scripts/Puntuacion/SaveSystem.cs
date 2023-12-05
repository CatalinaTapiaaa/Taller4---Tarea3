using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string fileName => "file";
    private static string fileExtension => "sav";

    public static void Save(object data)
    {
        string jsonString = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + $"/{fileName}.{fileExtension}", jsonString);
    }

    public static T Load<T>() where T : new()
    {
        T data = new T();

        if (GetIfFileExists())
        {
            string raw = File.ReadAllText(Application.persistentDataPath + $"/{fileName}.{fileExtension}");
            JsonUtility.FromJsonOverwrite(raw, data);
        }

        return data;
    }

    public static bool GetIfFileExists()
    {
        if (File.Exists(Application.persistentDataPath + $"/{fileName}.{fileExtension}")) return true;
        return false;
    }
}