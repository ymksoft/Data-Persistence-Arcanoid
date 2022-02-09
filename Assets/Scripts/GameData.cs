using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // File operation

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public string playerName;
    public string playerBestName;
    public int highScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            // Нам нужен один менеджер для всех сцен. Если он уже создан, другие убиваем при создании.
            // This pattern is called a singleton. You use it to ensure that only a single instance of the MainManager can ever exist
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerBestName;
        public int highScore;
    }
    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerBestName = playerBestName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerBestName = data.playerBestName;
            highScore = data.highScore;
        }
    }
}
