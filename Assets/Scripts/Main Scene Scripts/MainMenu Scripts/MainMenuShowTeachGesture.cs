using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuShowTeachGesture : MonoBehaviour
{
    public GameObject BlockerGameObject;
    public Toggle toggle;


    private static bool shownMainMenuGestureGuide = false;
    //private bool playerPrefdoNotShowAgainChecked;
    private void Awake()
    {
        //playerPrefdoNotShowAgainChecked = (PlayerPrefs.GetInt("doNotShowAgainChecked") != 0);

        if (BlockerGameObject)
        {
            if (!shownMainMenuGestureGuide)
                BlockerGameObject.SetActive(true);
            else
            {
                BlockerGameObject.SetActive(false);
            }
        }
       



       
    }

    public void SetdoNotShowAgainChecked()
    {
        shownMainMenuGestureGuide = toggle.isOn;

    }

    public void HideBlocker()
    {
        shownMainMenuGestureGuide = true;
        BlockerGameObject.SetActive(false);
    }

}
