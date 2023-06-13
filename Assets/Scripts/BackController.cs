using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    public MenuManager menuManager;

    void Start()
    {
        ////menuManager = GetComponent<MenuManager>();
        //sceneChanger = GetComponent<SceneChanger>();
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void GoBackTo()
    {
        

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
        Debug.Log("Go back to " + ButtonReferenceManager.Instance.storedButtonID + " scene with dthEnum " + ButtonReferenceManager.Instance.storedDTHButtonID);
        SceneChanger.Instance.ChangeToMainScene();
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
                SceneChanger.Instance.ChangeToARScene();
                break;
            case ButtonENUM.TOOLINFO:
                SceneChanger.Instance.ChangeToMainScene();
                menuManager.OnToolClicked();
                break;
            case ButtonENUM.ASSESSMENT:
                SceneChanger.Instance.ChangeToAssessmentScene();
                break;
            case ButtonENUM.DEMOVID:
                SceneChanger.Instance.ChangeToVideoScene();
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


