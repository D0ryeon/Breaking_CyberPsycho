using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Device;

public class FileIO
{
    private const string JSON_FILE_DIR = "/Data/";

    public static void SaveJsonFile<T>(T obj, string fileName)
    {
        string fileFullPath = $"{Application.dataPath}{JSON_FILE_DIR}{fileName}.json";

        string outputJson = "";

        if (File.Exists(fileFullPath))
        {
            string jsonText = File.ReadAllText(fileFullPath);
            List<T> listTobj = JsonConvert.DeserializeObject<List<T>>(jsonText);

            listTobj.Add(obj);

            outputJson = JsonConvert.SerializeObject(listTobj, Formatting.Indented);
            File.WriteAllText(fileFullPath, outputJson);
        }
        else
        {
            List<T> listTobj = new List<T>();
            listTobj.Add(obj);
            outputJson = JsonConvert.SerializeObject(listTobj, Formatting.Indented);
        }

        if (string.IsNullOrEmpty(outputJson))
            return;

        File.WriteAllText(fileFullPath, outputJson);
    }

    public static T LoadJsonFile<T>(string fileName)
    {
        string fileFullPath = $"{Application.dataPath}{JSON_FILE_DIR}{fileName}.json";

        if (!File.Exists(fileFullPath))
            return default(T);

        string json = File.ReadAllText(fileFullPath);
        T obj = JsonConvert.DeserializeObject<T>(json);
        return obj;
    }
}
