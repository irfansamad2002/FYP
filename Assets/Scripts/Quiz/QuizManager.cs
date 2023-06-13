using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QnA> QnA;
    public GameObject[] options;
    public int currentQn;

    public TMP_Text QuestionText;

    private void Start()
    {
        GenerateQn();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQn);
        GenerateQn();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQn].answers[i];
            if (QnA[currentQn].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQn()
    {
        currentQn = Random.Range(0, QnA.Count);

        QuestionText.text = QnA[currentQn].question;
        SetAnswers();
    }
}
