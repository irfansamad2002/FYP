using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizData : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text scoreText;

    public QuizManager quizManager;
    public HighScoreTable highScoreTable;

    [Header("List")]
    public List<string> PlayerNames = new List<string>();
    public List<int> PlayerScores = new List<int>();
    private int savedNamesListCount;
    private int savedScoresListCount;
    const string PLAYERPREFDATABASE = "highscoreTable";


    private void Awake()
    {
        //LoadData();
        //highScoreTable.AddHighscoreEntry(999, "test");
        //Debug.Log("added" + PlayerPrefs.GetString(PLAYERPREFDATABASE));
    }

    public void SaveNames()
    {
        //PlayerNames.Add(nameInput.text);
        //for (int i = 0; i < PlayerNames.Count; i++)
        //{
        //    PlayerPrefs.SetString("Names" + i, PlayerNames[i]);
        //    Debug.Log("Names: " + PlayerPrefs.GetString("Names" + i));
        //}
        //PlayerPrefs.SetInt("nameCount", PlayerNames.Count);

        PlayerPrefs.SetString("Names" , nameInput.text);
    }

    public void SaveScores()
    {
        //PlayerScores.Add(quizManager.score);
        //for (int i = 0; i < PlayerScores.Count; i++)
        //{
        //    PlayerPrefs.SetInt("Scores" + i, PlayerScores[i]);
        //    Debug.Log("Saved Score: " + PlayerPrefs.GetInt("Scores" + i));
        //}
        //PlayerPrefs.SetInt("scoreCount", PlayerScores.Count);

        PlayerPrefs.SetInt("Scores" , quizManager.score);
    }

    public void LoadData()
    {

        //PlayerPrefs.GetString("Names");
        //PlayerPrefs.GetInt("Scores");
        highScoreTable.AddHighscoreEntry(PlayerPrefs.GetInt("Scores"), PlayerPrefs.GetString("Names"));
        Debug.Log("load data with name " + PlayerPrefs.GetString("Names") + " with score " + PlayerPrefs.GetInt("Scores"));
        
    }
    public void DeleteData()
    {
        
    }
}
