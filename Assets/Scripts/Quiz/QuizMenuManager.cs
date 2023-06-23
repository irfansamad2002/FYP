using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMenuManager : MonoBehaviour
{
    [Header("Top Parent")]
    [SerializeField] private GameObject TopParent;
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Enter Name")]
    [SerializeField] private GameObject EnterNamePage;

    [Header("Quiz Menu")]
    [SerializeField] private GameObject QuizMenu;
    [SerializeField] private Button Option1Button;
    [SerializeField] private Button Option2Button;
    [SerializeField] private Button Option3Button;
    [SerializeField] private Button Option4Button;

    [Header("Correct/Wrong Page")]
    [SerializeField] private GameObject CorrectWrongPage;
    [SerializeField] private TMP_Text CorrectWrongText;
    [SerializeField] private Button NextQnButton;

    [Header("Quiz Over Menu")]
    [SerializeField] private GameObject QuizOverMenu;
    [SerializeField] private Button QuizToHomeButton;
    [SerializeField] private Button TryAgainButton;
    
    [Header("Scripts")]
    public SceneChanger sceneChanger;
    public QuizManager quizManager;
    public AnswerScript answerScript;
    public QuizData quizData;

    [Header("Others")]
    public TMP_Text ScoreText;
    public int qnNumber;
    void Start()
    {
        TopParent.SetActive(true);
        EnterNamePage.SetActive(true);
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        QuizMenu.SetActive(false);
        CorrectWrongPage.SetActive(false);
        QuizOverMenu.SetActive(false);
        qnNumber = 1;
    }

    public void OnCancelClicked()
    {
        sceneChanger.ChangeToMainScene();
    }

    public void OnContinueClicked()
    {
        // save name playerprefs
        quizData.SaveName();
        // continue to quiz
        BackButton.SetActive(true);
        EnterNamePage.SetActive(false);
        QuizMenu.SetActive(true);
    }

    public void OnHomeClicked()
    {
        sceneChanger.ChangeToMainScene();
    }

    public void OnOptionClicked()
    {
        TopParent.SetActive(false);
        QuizMenu.SetActive(false);

        // if on questions <= 9
        if (qnNumber < 10)
        {
            qnNumber += 1;
            CorrectWrongPage.SetActive(true);
            if (answerScript.isCorrect)
            {
                CorrectWrongText.text = "Try Again!";
                Debug.Log("isCorrect is: " + answerScript.isCorrect);
            }
            else
            {
                CorrectWrongText.text = "Good Job!";
                Debug.Log("isCorrect is: " + answerScript.isCorrect);
            }
        }
        else
        {
            // if on question 10 
            //ScoreText.text = quizManager.score + "/10";
            //Debug.Log(quizManager.score + "/10");
            QuizOverMenu.SetActive(true);
        }
    }

    

    public void OnNextQnClicked()
    {
        CorrectWrongPage.SetActive(false);
        TopParent.SetActive(true);
        QuizMenu.SetActive(true);
    }

    public void QuizOver()
    {
        QuizMenu.SetActive(false);
        QuizOverMenu.SetActive(true);
        ScoreText.text = quizManager.score + "/10";
        Debug.Log(quizManager.score + "/10");
        quizData.SaveScore();
    }

    #region when on score page
    public void OnTryAgainClicked()
    {
        TopParent.SetActive(true);
        QuizMenu.SetActive(true);
        QuizOverMenu.SetActive(false);
        quizManager.Retry();
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
