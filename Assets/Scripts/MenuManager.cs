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
    [SerializeField] private GameObject Logo;

    [Header("Main Menu")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private Button DentalTherapyButton;
    [SerializeField] private Button DentalHealthButton;

    //[Header("Selection Screen")]
    //[SerializeField] private GameObject MainMenu;
    //[SerializeField] private Button ToolsButton;
    //[SerializeField] private Button AssessmentButton;

    [Header("Tool Selection")]
    [SerializeField] private GameObject ToolSelectionMenu;
    [SerializeField] private GameObject AssessmentButton;
    //[SerializeField] private GameObject ScanButton; // only for DT page

    [Header("Tool Info")]
    [SerializeField] private GameObject ToolInfoMenu;
    //[SerializeField] private Button DemoVideoButton;

    [Header("Settings")]
    [SerializeField] private GameObject SettingsMenu;


    [Header("Toogle On if want to start from Menu")]
    [SerializeField] private bool startFromMenu;

    public SceneChanger sceneChanger;
    public SettingsManager settingsManager;
    void Start()
    {
        if (startFromMenu)
        {
            Logo.SetActive(true);
            HomeButton.SetActive(false);
            BackButton.SetActive(false);
            MainMenu.SetActive(true);
            ToolSelectionMenu.SetActive(false);
            ToolInfoMenu.SetActive(false);
            //ScanButton.SetActive(false);
            SettingsMenu.SetActive(false);
        }
        AssessmentButton.SetActive(false);
        if (ButtonReferenceManager.Instance.storedButtonID == ButtonENUM.MAINSCENE)
        {
            Debug.Log("Suppose to g back home");
            HomeButton.SetActive(false);
            BackButton.SetActive(false);
            MainMenu.SetActive(true);
            ToolSelectionMenu.SetActive(false);
            ToolInfoMenu.SetActive(false);
            //ScanButton.SetActive(false);
            SettingsMenu.SetActive(false);
            AssessmentButton.SetActive(false);
        }

        else if (ButtonReferenceManager.Instance.storedButtonID == ButtonENUM.TOOLSELECTION || ButtonReferenceManager.Instance.storedButtonID == ButtonENUM.TOOLINFO)//check if come from tool selection
        {
            Debug.Log("come from tool selection");
            OnDHorDTClicked();
            if (ButtonReferenceManager.Instance.storedButtonID == ButtonENUM.TOOLINFO)
            {
                OnToolClicked();
                ButtonReferenceManager.Instance.storedButtonID = ButtonENUM.TOOLSELECTION;
            }
            else
            {
                ButtonReferenceManager.Instance.storedButtonID = ButtonENUM.MAINSCENE;
                Debug.Log("show the tool info wth the index of  " + ButtonReferenceManager.Instance.storedIndex);

            }
        }
    }

    #region from main menu
    // click
    // or DH button from main menu
    public void OnDHorDTClicked()
    {
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        Logo.SetActive(false);
        MainMenu.SetActive(false);
        ToolSelectionMenu.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);
        AssessmentButton.SetActive(true);

        //// scan only for DT page
        //if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DT)
        //{
        //    //ScanButton.SetActive(true);
        //}
        //else if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DH)
        //{
        //    ScanButton.SetActive(false);
        //}
    }   

    //  from main menu to ar scene
    public void OnScanClicked()
    {
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        sceneChanger.ChangeToScanScene();
    }

    public void OnScoresClicked()
    {
        sceneChanger.ChangeToScoreScene();
        //AudioPlayer.Instance.PlayAudioOneShot(0);
    }

    public void OnSettingsClicked()
    {
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        Logo.SetActive(false);
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);
    }
    #endregion


    #region from tool selection
    //  from tool selection to assesment
    public void OnAssessmentClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        sceneChanger.ChangeToQuizScene();
    }

    //  from tool selection to tool info
    public void OnToolClicked()
    {
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(true);
        AssessmentButton.SetActive(false);
    }

    public void OnSpawnClicked()
    {
        AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        sceneChanger.ChangeToSpawnScene();
    }

    #endregion


    #region from tool info
    //  from tool info to tool selection
    public void FromInfoToSelection()
    {
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
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
        AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        //ToolInfoMenu.SetActive(false);
        sceneChanger.ChangeToVideoScene();
    }

    //  Home button or go back to main menu
    public void OnHomeClicked()
    {
        ButtonReferenceManager.Instance.storedDTHButtonID = DTHEnum.NONE;
        //AudioPlayer.Instance.PlayAudioOneShot(0, .5f);
        Logo.SetActive(true);
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        MainMenu.SetActive(true);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(false);
        AssessmentButton.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    public void OnBackClickedFromSettings()
    {
        //if (SettingsMenu.activeSelf)
        //{
        //    SettingsMenu.SetActive(false);
        //    MainMenu.SetActive(true);
        //    settingsManager.SaveVolume();
        //    Debug.Log("Saved volume");
        //}

        SettingsMenu.SetActive(false);
        Logo.SetActive(true);
        MainMenu.SetActive(true);
        settingsManager.SaveVolume();
        Debug.Log("Saved volume");
    }
}