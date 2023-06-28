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
            //Debug.Log("Saved name: " + PlayerNames[i]);
            Debug.Log("Names: " + PlayerPrefs.GetString("Names" + i));
        }
        //PlayerPrefs.SetString("Names", nameInput.text);
        PlayerPrefs.SetInt("nameCount", PlayerNames.Count);
    }

    public void SaveScores()
    {
        PlayerScores.Add(quizManager.score);
        for (int i = 0; i < PlayerScores.Count; i++)
        {
            PlayerPrefs.SetInt("Scores" + i, PlayerScores[i]);
            //Debug.Log("Saved Score: " + PlayerScores[i]);
            Debug.Log("Saved Score: " + PlayerPrefs.GetInt("Scores" + i));
        }
        //PlayerPrefs.SetInt("Scores", quizManager.score);
        PlayerPrefs.SetInt("scoreCount", PlayerScores.Count);
    }

    public void LoadData()
    {
        PlayerPrefs.GetString("Names");
        PlayerPrefs.GetInt("Scores");
        //PlayerNames.Clear();
        //PlayerScores.Clear();
        //savedNamesListCount = PlayerPrefs.GetInt("nameCount");
        //savedScoresListCount = PlayerPrefs.GetInt("scoreCount");

        //Debug.Log(savedNamesListCount + " " + savedScoresListCount);
        //for (int i = 0; i < savedNamesListCount; i++)
        //{
        //    string player = PlayerPrefs.GetString("Names" + i);
        //    PlayerNames.Add(player);
        //}

        //for (int i = 0; i < savedScoresListCount; i++)
        //{
        //    int score = PlayerPrefs.GetInt("Scores" + i);
        //    PlayerScores.Add(score);
        //}

        //Debug.Log(PlayerPrefs.GetString("Names0"));

    }
    public void DeleteData()
    {
        
    }
}
