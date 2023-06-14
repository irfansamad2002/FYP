using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizMenuManager : MonoBehaviour
{
    [Header("Top Parent")]
    [SerializeField] private GameObject TopParent;
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Assessment Menu")]
    [SerializeField] private GameObject AssessmentMenu;
    [SerializeField] private Button Option1Button;
    [SerializeField] private Button Option2Button;
    [SerializeField] private Button Option3Button;
    [SerializeField] private Button Option4Button;

    [Header("Correct/Wrong Page")]
    [SerializeField] private GameObject CorrectWrongPage;
    [SerializeField] private Button NextQnButton;

    [Header("Score Menu")]
    [SerializeField] private GameObject ScoreMenu;
    [SerializeField] private Button ScoreHomeButton;
    [SerializeField] private Button TryAgainButton;

    public SceneChanger sceneChanger;
    public QuizManager quizManager;
    void Start()
    {
        TopParent.SetActive(true);
        HomeButton.SetActive(false);
        BackButton.SetActive(true);
        AssessmentMenu.SetActive(true);
        CorrectWrongPage.SetActive(false);
        ScoreMenu.SetActive(false);
    }

    public void OnHomeClicked()
    {
        sceneChanger.ChangeToMainScene();
    }

    public void OnOptionClicked()
    {
        TopParent.SetActive(false);
        AssessmentMenu.SetActive(false);

        // if on questions <= 9
        CorrectWrongPage.SetActive(true);

        // if on question 10 
        //ScoreMenu.SetActive(true);
    }

    public void OnNextQnClicked()
    {
        CorrectWrongPage.SetActive(false);
        TopParent.SetActive(true);
        AssessmentMenu.SetActive(true);

    }

    #region when on score page
    public void OnTryAgainClicked()
    {
        TopParent.SetActive(true);
        AssessmentMenu.SetActive(true);
        ScoreMenu.SetActive(false);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
