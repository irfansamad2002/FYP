using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMenuManager : MonoBehaviour
{
    [Header("Header")]
    [SerializeField] private GameObject safeArea;

    [Header("Top Parent")]
    [SerializeField] private GameObject TopParent;
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Enter Name")]
    [SerializeField] private GameObject EnterNamePage;

    [Header("Quiz Menu")]
    [SerializeField] private GameObject QuizMenu;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Button Option1Button;
    [SerializeField] private Button Option2Button;
    [SerializeField] private Button Option3Button;
    [SerializeField] private Button Option4Button;

    [Header("Correct/Wrong Page")]
    [SerializeField] private GameObject CorrectWrongPage;
    [SerializeField] private TMP_Text CorrectWrongText;
    [SerializeField] private GameObject GJTAImage;
    [SerializeField] private GameObject NextQnButton;

    [Header("Quiz Over Menu")]
    [SerializeField] private GameObject QuizOverMenu;
    [SerializeField] private Button QuizToHomeButton;
    [SerializeField] private Button TryAgainButton;
    
    [Header("Scripts")]
    public SceneChanger sceneChanger;
    public QuizManager quizManager;
    public AnswerScript answerScript;
    public QuizData quizData;
    public QuizTimer quizTimer;

    [Header("Others")]
    public TMP_Text ScoreText;
    public int qnNumber;

    [Header("Background Images")]
    public Sprite enterNameBG;
    public Sprite mainBG;
    public Sprite correctBG;
    public Sprite wrongBG;

    [Header("Good Job/Try Again Images")]
    public Sprite goodJobImage;
    public Sprite tryAgainImage;
    public Sprite nextQnRight;
    public Sprite nextQnWrong;

    private int latestButtonIndex;
    //private float timeRemaining = 10;
    //private bool isTimerMoving = false;

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
        changeQuizBG(0);
    }

    void Update()
    {
        timerText.text = "Time Remaining: " + quizTimer.getTimeRemaining().ToString("#");
        if (quizTimer.getIsTimerMoving() == true && quizTimer.getTimeRemaining() > 0)
        {
            quizTimer.updateTimer();
        }

        if (quizTimer.getTimeRemaining() < 0)
        {
            quizTimer.resetTimer();
            quizManager.Wrong();
        }
    }

    public void OnBackClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnCancelClicked()
    {
        Debug.Log("Button id " + ButtonReferenceManager.Instance.storedButtonID);
        ButtonReferenceManager.Instance.storedIndex = 0;
        //ButtonReferenceManager.Instance.storedDTHButtonID = DTHEnum.NONE;
        sceneChanger.ChangeToMainScene();
        //AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnContinueClicked()
    {
        if (quizData.nameInput.text != "")
        {
            // save name playerprefs
            quizData.SaveNames();
            // continue to quiz
            BackButton.SetActive(true);
            EnterNamePage.SetActive(false);
            QuizMenu.SetActive(true);
            changeQuizBG(1);

            // start timer when player starts quiz
            quizTimer.startTimer();
            //Debug.Log("Timer started");
        }
        AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnHomeClicked()
    {
        ButtonReferenceManager.Instance.storedDTHButtonID = DTHEnum.NONE;
        sceneChanger.ChangeToMainScene();
        AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void SetLatestButtonIndex(int index)
    {
        latestButtonIndex = index;
    }

    public int GetLatestButtonIndex()
    {
        return latestButtonIndex;
    }
    public void OnOptionClicked()
    {
        TopParent.SetActive(false);
        QuizMenu.SetActive(false);

        // if on questions <= 9
        if (qnNumber <= 10)
        {
            quizTimer.setIsTimerMoving(false);
            //Debug.Log("Timer stopped");
            qnNumber += 1;
            CorrectWrongPage.SetActive(true);
        
            if (quizManager.CheckIfButtonIsCorrect(GetLatestButtonIndex()))
            {
                CorrectWrongText.text = "Good Job!";
                changeQuizBG(2);
                GJTAImage.GetComponent<Image>().sprite = goodJobImage;
                NextQnButton.GetComponent<Image>().sprite = nextQnRight;
            }
            else
            {
                CorrectWrongText.text = "Try Again!";
                changeQuizBG(3);
                GJTAImage.GetComponent<Image>().sprite = tryAgainImage;
                NextQnButton.GetComponent<Image>().sprite = nextQnWrong;
            }
        }
        //else if (qnNumber == 11)
        //{
        //    QuizOver();
        //}
        //else
        //{
        //    // if on question 10 
        //    CorrectWrongPage.SetActive(true);
        //    if (CorrectWrongPage.activeInHierarchy == true)
        //    {
        //        QuizOverMenu.SetActive(true);
        //    }
        //}
    }

    public void OnNextQnClicked()
    {
        CorrectWrongPage.SetActive(false);
        TopParent.SetActive(true);
        if (qnNumber <= 10)
        {
            QuizMenu.SetActive(true);
            changeQuizBG(1);
            // start timer after next question is pressed
            quizTimer.startTimer();
        }
        else if (qnNumber == 11)
        {
            QuizOver();
            QuizOverMenu.SetActive(true);

            if (QuizOverMenu.activeInHierarchy == true)
            {
                changeQuizBG(1);
            }
        }
        AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void QuizOver()
    {
        BackButton.SetActive(false);
        QuizMenu.SetActive(false);
        ScoreText.text = quizManager.score + "/10";
        quizData.SaveScores();
        quizData.LoadData();
        //changeQuizBG(1);
        quizTimer.setIsTimerMoving(false);
        //Debug.Log(quizManager.score + "/10");
        //Debug.Log("Timer stopped");
    }

    #region when on score page
    public void OnTryAgainClicked()
    {
        TopParent.SetActive(true);
        QuizMenu.SetActive(true);
        QuizOverMenu.SetActive(false);
        quizManager.Retry();
        AudioPlayer.Instance.PlayAudioOneShot(0);
    }
    #endregion
    public void changeQuizBG(int index)
    {
        if (index == 0)
        {
            safeArea.GetComponent<Image>().sprite = enterNameBG;
        }
        else if (index == 1)
        {
            safeArea.GetComponent<Image>().sprite = mainBG;
        }
        else if (index == 2)
        {
            safeArea.GetComponent<Image>().sprite = correctBG;
        }
        else if (index == 3)
        {
            safeArea.GetComponent<Image>().sprite = wrongBG;
        }
        //else if (index == 4)
        //{
        //    safeArea.GetComponent<Image>().sprite = scoreBG;
        //}
    }
}
