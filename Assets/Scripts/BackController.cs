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

    

    public void GoBackTo()
    {
        if (checkIfInMainScene())
        {
            //In the same scene
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
                //Debug.Log("go back to MAINSCENE");
                menuManager.OnHomeClicked();
                break;
            case ButtonENUM.TOOLSELECTION:
                //Debug.Log("go back to SELECTIONSCREEN");
                menuManager.FromInfoToSelection();
                break;
            case ButtonENUM.ARBIT:
                //Debug.Log("go back to ARBIT");
                SceneChanger.Instance.ChangeToARScene();
                break;
            case ButtonENUM.TOOLINFO:
                //Debug.Log("go back to TOOLINFO");
                SceneChanger.Instance.ChangeToMainScene();
                menuManager.OnToolClicked();
                break;
            case ButtonENUM.ASSESSMENT:
                //Debug.Log("go back to ASSESSMENT");
                SceneChanger.Instance.ChangeToQuizScene();
                break;
            case ButtonENUM.DEMOVID:
                //Debug.Log("go back to DEMOVID");
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


