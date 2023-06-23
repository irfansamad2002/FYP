using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQn;

    public TMP_Text QuestionNumber;
    public TMP_Text QuestionText;
    public TMP_Text CorrectWrongText;

    public int totalQuestions = 0;
    public int score = 0;
    public bool isQuizOver = false;

    [Header("QuizMenuManager")]
    public QuizMenuManager quizMenuManager;

    [Header("Answer Script")]
    public AnswerScript answerScript;

    private void Start()
    {
        totalQuestions = QnA.Count;
        //QuestionNumber.text = 1.ToString();
        GenerateQn();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Correct()
    {
        score += 1;
        QnA.RemoveAt(currentQn);
        GenerateQn();
        //SetCorrectWrongText();
    }

    public void Wrong()
    {
        // wrong answer
        QnA.RemoveAt(currentQn);
        GenerateQn();
        //SetCorrectWrongText();
    }

    //public void SetCorrectWrongText()
    //{
    //    //Debug.Log("isCorrect is " + answerScript.isCorrect);
    //    if (answerScript.isCorrect)
    //    {
    //        Debug.Log("good job");
    //        CorrectWrongText.text = "Good Job!";
    //    }
    //    else
    //    {
    //        Debug.Log("try again");
    //        CorrectWrongText.text = "Try again!";
    //    }
    //}

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            answerScript.isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQn].answers[i];
            //CorrectWrongText.text = "Try Again!";
            //Debug.Log("isCorrect is: " + answerScript.isCorrect);

            if (QnA[currentQn].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                answerScript.isCorrect = true;
                //if (options[i].GetComponent<AnswerScript>().isCorrect == true)
                //{
                //    CorrectWrongText.text = "Good Job!";
                //    Debug.Log("isCorrect is: " + answerScript.isCorrect);
                //}
            }
            Debug.Log(options[i].GetComponent<AnswerScript>().isCorrect);
        }
        //if (answerScript.isCorrect)
        //{
        //    Debug.Log("TRY AGAIN TEXT");
        //    CorrectWrongText.text = "Try Again!";
        //}
        //else
        //{
        //    Debug.Log("GOOD JOB TEXT");
        //    CorrectWrongText.text = "Good Job!";
        //}
    }

    void GenerateQn()
    {
        if (QnA.Count > 5)
        {
            currentQn = Random.Range(0, QnA.Count);
            QuestionNumber.text = quizMenuManager.qnNumber.ToString();
            QuestionText.text = QnA[currentQn].question;
            SetAnswers();
        }
        else
        {
            isQuizOver = true;
            quizMenuManager.QuizOver();
            Debug.Log("Out of questions");
            Debug.Log(isQuizOver);
        }
    }
}
