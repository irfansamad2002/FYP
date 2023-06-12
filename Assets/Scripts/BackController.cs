using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    public MenuManager menuManager;
    public SceneChanger sceneChanger;

    void Start()
    {
        menuManager = GetComponent<MenuManager>();
        sceneChanger = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void GoBackTo()
    {
        Debug.Log("id" + ButtonReferenceManager.Instance.storedButtonID);
        Debug.Log("dth" + ButtonReferenceManager.Instance.storedDTHButtonID);

        if(checkIfInMainScene())
        {
            TurnOnOffGameObj(ButtonReferenceManager.Instance.storedButtonID, ButtonReferenceManager.Instance.storedDTHButtonID);
        }
        else
        {
            changeBackToOldScene();
        }

    }

    private void changeBackToOldScene()
    {

    }

    private void TurnOnOffGameObj(ButtonENUM storedButtonID, DTHEnum storedDTHButtonID)
    {
        switch (storedButtonID)
        {
            case ButtonENUM.MAINSCENE:
                menuManager.OnHomeClicked();
                break;
            case ButtonENUM.SELECTIONSCREEN:
                menuManager.OnToolClicked();
                break;
            case ButtonENUM.ARBIT:
                sceneChanger.ChangeToARScene();
                break;
            case ButtonENUM.TOOLINFO:
                sceneChanger.ChangeToMainScene();
                menuManager.OnToolClicked();
                break;
            case ButtonENUM.ASSESSMENT:
                sceneChanger.ChangeToAssessmentScene();
                break;
            case ButtonENUM.DEMOVID:
                sceneChanger.ChangeToVideoScene();
                break;
        }
    }

    private bool checkIfInMainScene()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main Scene"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


