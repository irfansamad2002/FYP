using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizData : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text scoreText;

    public QuizManager quizManager;

    public void SaveName()
    {
        PlayerPrefs.SetString("Name", nameInput.text);
        Debug.Log("Saved name: " + PlayerPrefs.GetString("Name"));
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", quizManager.score);
        Debug.Log("Saved score: " + PlayerPrefs.GetInt("Score"));
    }

    public void LoadData()
    {
        PlayerPrefs.GetString("Name");
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Name");

    }
}
