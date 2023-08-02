using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTimer : MonoBehaviour
{
    private float timeRemaining = 15;
    private bool isTimerMoving = false;

    [Header("Scripts")]
    public QuizMenuManager quizMenuManager;
    public QuizManager quizManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startTimer()
    {
        timeRemaining = 15;
        isTimerMoving = true;
        Debug.Log("Timer started");
    }

    public void resetTimer()
    {
        timeRemaining = 15;
        isTimerMoving = false;
        quizMenuManager.OnOptionClicked();
        quizManager.QuestionNumber.text = "Question " + quizMenuManager.qnNumber.ToString();
    }

    public void updateTimer()
    {
        timeRemaining -= Time.deltaTime;
    }

    public bool getIsTimerMoving()
    {
        return isTimerMoving;
    }
    public void setIsTimerMoving(bool timerMoving)
    {
        isTimerMoving = timerMoving;
    }

    public float getTimeRemaining()
    {
        return timeRemaining;
    }
}
