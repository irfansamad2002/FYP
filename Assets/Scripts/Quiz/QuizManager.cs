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
    public bool correctAnsPressed = false;

    [Header("QuizMenuManager")]
    public QuizMenuManager quizMenuManager;

    [Header("Answer Script")]
    public AnswerScript answerScript;

    private void Start()
    {
        //Debug.Log("preesed next");

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
        //Debug.Log("preesed next");
        score += 1;
        QnA.RemoveAt(currentQn);
        GenerateQn();
        //SetCorrectWrongText();
    }

    public void Wrong()
    {
        //Debug.Log("preesed next");
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
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQn].answers[i];
            //Debug.Log("isCorrect is: " + options[i].GetComponent<AnswerScript>().isCorrect);
            //Debug.Log(QnA[currentQn].correctAnswer + " i: " + (i + 1));

            if (QnA[currentQn].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                //correctAnsPressed = true;
                //Debug.Log("isCorrect is: " + options[i].GetComponent<AnswerScript>().isCorrect);
            }
        }

        if (quizMenuManager.GetLatestButtonIndex() == QnA[currentQn].correctAnswer)
        {
            correctAnsPressed = true;
            Debug.Log("button index: " + quizMenuManager.GetLatestButtonIndex());
            Debug.Log(QnA[currentQn].correctAnswer);
        }
        else
        {
            correctAnsPressed = false;
            Debug.Log("button index: " + quizMenuManager.GetLatestButtonIndex());
            Debug.Log(QnA[currentQn].correctAnswer);
        }
    }

    //public bool CheckIfButtonIsCorrect()
    //{
    //    for (int i = 0; i < options.Length; i++)
    //    {
    //        options[i].GetComponent<AnswerScript>().isCorrect = false;
    //        options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQn].answers[i];
    //        //Debug.Log("isCorrect is: " + options[i].GetComponent<AnswerScript>().isCorrect);
    //        //Debug.Log(QnA[currentQn].correctAnswer + " i: " + (i + 1));


    //    }
    //}

    void GenerateQn()
    {
        if (QnA.Count > 5) // number of questions - 10, if 50 questions, input "> 40"
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
            //Debug.Log("Out of questions");
            //Debug.Log(isQuizOver);
        }
    }
}
