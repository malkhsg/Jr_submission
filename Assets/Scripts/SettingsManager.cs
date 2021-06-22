using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public string playerName;
    public int bestPlayerScore;
    public string bestPlayerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
    }

   
    public bool OnNewPlayerScore(int curScore)
    {
        if (curScore <= bestPlayerScore)
        {
            return false;
        }

        bestPlayerScore = curScore;
        bestPlayerName = playerName;
        SaveBestPlayer();

        return true;
    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.bestPlayerScore = bestPlayerScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerScore = data.bestPlayerScore;
            bestPlayerName = data.bestPlayerName;
        }
    }

}
