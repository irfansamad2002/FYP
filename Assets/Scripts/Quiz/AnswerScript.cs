using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
  
    public void Answer()
    {
        
        if (isCorrect)
        {
            //Debug.Log("CORRECT ANSWER");
            quizManager.Correct();
        }
        else
        {
            //Debug.Log("WRONG ANSWER");
            quizManager.Wrong();
        }
    }

    public bool GetIsCorrect()
    {
        return isCorrect;
    }
}
