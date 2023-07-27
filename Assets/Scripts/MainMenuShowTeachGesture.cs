using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuShowTeachGesture : MonoBehaviour
{
    public GameObject BlockerGameObject;
    public Toggle toggle;


    private static bool shownGestureGuide = false;
    //private bool playerPrefdoNotShowAgainChecked;
    private void Awake()
    {
        //playerPrefdoNotShowAgainChecked = (PlayerPrefs.GetInt("doNotShowAgainChecked") != 0);

        if (BlockerGameObject)
        {
            if (!shownGestureGuide)
                BlockerGameObject.SetActive(true);
            else
            {
                BlockerGameObject.SetActive(false);
            }
        }
       



        //if (!playerPrefdoNotShowAgainChecked)//the user checked the do not show again
        //    BlockerGameObject.SetActive(true);
        //else
        //    BlockerGameObject.SetActive(false);

        //Debug.Log("playperPrefBool " + playerPrefdoNotShowAgainChecked);
       
    }

    public void SetdoNotShowAgainChecked()
    {
        shownGestureGuide = toggle.isOn;

    }

    public void HideBlocker()
    {
        shownGestureGuide = true;
        BlockerGameObject.SetActive(false);
    }

}
