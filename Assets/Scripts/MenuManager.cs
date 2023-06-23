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
    [SerializeField] private Button DemoVideoButton;

    public SceneChanger sceneChanger;

    void Start()
    {
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        MainMenu.SetActive(true);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(false);

    }

    // main menu page
    public void OnDTHClicked()
    {
        MainMenu.SetActive(false);
        ToolSelectionMenu.SetActive(true);
        BackButton.SetActive(true);
    }


    #region selection screen buttons
    public void OnToolSelectClicked()
    {
        MainMenu.SetActive(false);
        ToolSelectionMenu.SetActive(true);
        HomeButton.SetActive(false);
        BackButton.SetActive(true);
    }

    public void OnAssessmentClicked()
    {
        // change to assessment scene
        sceneChanger.ChangeToAssessmentScene();
    }

    public void OnScanClicked()
    {
        // change to AR scene
        sceneChanger.ChangeToARScene();
    }

    public void OnScoresClicked()
    {
        sceneChanger.ChangeToScoreScene();
    }
    #endregion

    #region tool clicked from selection screen
    public void OnToolClicked()
    {
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(true);
        BackButton.SetActive(true);
    }
    #endregion

    #region Tool info screen
    public void OnDemoVidClicked()
    {
        ToolInfoMenu.SetActive(false);
        // change scene to demo video scene
        sceneChanger.ChangeToVideoScene();
    }
    #endregion

    public void OnHomeClicked()
    {
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        MainMenu.SetActive(true);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(false);
    }

    // main menu active 
    public void MainMenuActive()
    {
        HomeButton.SetActive(false);
        BackButton.SetActive(false);
        MainMenu.SetActive(true);
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(false);
    }
    // tool selection screen active
    public void ToolSelectActive()
    {
        MainMenu.SetActive(false);
        ToolSelectionMenu.SetActive(true);
        HomeButton.SetActive(true);
    }

    // tool info screen active
    public void ToolInfoActive()
    {
        ToolSelectionMenu.SetActive(false);
        ToolInfoMenu.SetActive(true);
        BackButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //if (AssessmentMenu.active == false)
        //{
        //    Debug.Log("Lol");
        //}
    }
}
