using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;

    public int hiScore;
    public string currentPlayer;
    public string scorer;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int hiScore;
        public string scorer;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.hiScore = hiScore;
        data.scorer = scorer;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiScore = data.hiScore;
            scorer = data.scorer;
        }
    }
}
