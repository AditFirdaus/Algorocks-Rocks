using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
    public System.DateTime date = System.DateTime.Now;
    public int score = 0;

    public static void Save(ScoreData data)
    {// save to date and minute and second
        string path = Application.persistentDataPath + $"/Scores/{data.date.ToString("MM-dd-yyyy-HH-mm-ss")}.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static ScoreData[] LoadAll()
    {
        string path = Application.persistentDataPath + "/Scores/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string[] files = Directory.GetFiles(path);
        ScoreData[] datas = new ScoreData[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            string json = File.ReadAllText(files[i]);
            datas[i] = JsonUtility.FromJson<ScoreData>(json);
        }
        return datas;
    }

    public static ScoreData Load(string date)
    {
        string path = Application.persistentDataPath + $"/Scores/{date}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ScoreData>(json);
        }
        return new ScoreData();
    }
}

public static class ScoreDataUtillity
{
    public static void Sort(this ScoreData[] _datas)
    {
        System.Array.Sort(_datas, (a, b) => b.score.CompareTo(a.score));
    }


}
