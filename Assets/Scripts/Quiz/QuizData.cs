using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizData : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text scoreText;

    public QuizManager quizManager;

    [Header("List")]
    public List<string> PlayerNames = new List<string>();
    public List<int> PlayerScores = new List<int>();
    private int savedNamesListCount;
    private int savedScoresListCount;

    private void Awake()
    {
        LoadData();
    }

    public void SaveNames()
    {
        PlayerNames.Add(nameInput.text);
        for (int i = 0; i < PlayerNames.Count; i++)
        {
            PlayerPrefs.SetString("Names" + i, PlayerNames[i]);
            Debug.Log("Names: " + PlayerPrefs.GetString("Names" + i));
        }
        PlayerPrefs.SetInt("nameCount", PlayerNames.Count);
    }

    public void SaveScores()
    {
        PlayerScores.Add(quizManager.score);
        for (int i = 0; i < PlayerScores.Count; i++)
        {
            PlayerPrefs.SetInt("Scores" + i, PlayerScores[i]);
            Debug.Log("Saved Score: " + PlayerPrefs.GetInt("Scores" + i));
        }
        PlayerPrefs.SetInt("scoreCount", PlayerScores.Count);
    }

    public void LoadData()
    {
        PlayerPrefs.GetString("Names");
        PlayerPrefs.GetInt("Scores");
    }
    public void DeleteData()
    {
        
    }
}
