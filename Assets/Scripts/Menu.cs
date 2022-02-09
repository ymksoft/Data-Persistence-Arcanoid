using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public Text BestScoreText;
    public InputField playerName;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.LoadGameData();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.highScore > 0)
        {
            BestScoreText.text = "Best score: " + GameData.Instance.playerBestName + ", " + GameData.Instance.highScore;
        }
        else
        {
            BestScoreText.text = "Best score: No entries";
        }
            
    }
    public void StartNew()
    {
        GameData.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        GameData.Instance.SaveGameData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
