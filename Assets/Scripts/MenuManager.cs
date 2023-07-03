using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [Header("Top Parent")]
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Main Menu")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private Button DentalTherapyButton;
    [SerializeField] private Button DentalHealthButton;
    [SerializeField] private Button ScanButton; 

    //[Header("Selection Screen")]
    //[SerializeField] private GameObject MainMenu;
    //[SerializeField] private Button ToolsButton;
    //[SerializeField] private Button AssessmentButton;

    [Header("Tool Selection")]
    [SerializeField] private GameObject ToolSelectionMenu;
    [SerializeField] private GameObject AssessmentButton;

    [Header("Tool Info")]
    [SerializeField] private GameObject ToolInfoMenu;
    //[SerializeField] private Button DemoVideoButton;

    public SceneChanger sceneChanger;

    [Header("Toogle On if want to start from Menu")]
    [SerializeField] private bool startFromMenu;

    void Start()
    {
        if (startFromMenu)
        {
            HomeButton.SetActive(false);
            BackButton.SetActive(false);
            MainMenu.SetActive(true);
            ToolSelectionMenu.SetActive(false);
            ToolInfoMenu.SetActive(false);
        }
        AssessmentButton.SetActive(false);

    }

    #region from main menu
    // click DT or DH button from main menu
    public void OnDHorDTClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        MainMenu.SetActive(false);
        ToolSelectionMenu.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);
        AssessmentButton.SetActive(true);

    }

    //  from main menu to ar scene
    public void OnScanClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        sceneChanger.ChangeToARScene();
    }

    public void OnScoresClicked()
    {
        sceneChanger.ChangeToScoreScene();
    }
    #endregion


    #region from tool selection
    //  from tool selection to assesment
    public void OnAssessmentClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        sceneChanger.ChangeToQuizScene();
    }

    //  from tool selection to tool info
    public void OnToolClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(true);
        AssessmentButton.SetActive(false);
    }
    #endregion


    #region from tool info
    //  from tool info to tool selection
    public void FromInfoToSelection()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        ToolSelectionMenu.SetActive(true);
        ToolInfoMenu.SetActive(false);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);
        AssessmentButton.SetActive(true);
        ButtonReferenceManager.Instance.storedButtonID = ButtonENUM.MAINSCENE;
    }
    //  irfan note: from tool info to demo



    #endregion

    //  irfan note: NEED TO CHANGE CFM DOUBLE CFM
    public void OnDemoVidClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        //ToolInfoMenu.SetActive(false);
        sceneChanger.ChangeToVideoScene();
    }

    //  Home button / go back to main menu
    public void OnHomeClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(1, .5f);
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        MainMenu.SetActive(true);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(false);
        AssessmentButton.SetActive(false);
    }

}
