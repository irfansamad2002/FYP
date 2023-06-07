using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                break;
            case ButtonENUM.SELECTIONSCREEN:
                break;
            case ButtonENUM.ARBIT:
                break;
            case ButtonENUM.TOOLINFO:
                break;
            case ButtonENUM.ASSESSMENT:
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


