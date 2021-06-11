using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Text scoreText;
    public InputField nameField;

    private void Awake()
    {
        ScoreHandler.Instance.LoadScore();
        
        scoreText.text = "Highscore: " + ScoreHandler.Instance.scorer + " : " + ScoreHandler.Instance.hiScore;
        
    }

    public void StartNew()
    {
        ScoreHandler.Instance.currentPlayer = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreHandler.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}