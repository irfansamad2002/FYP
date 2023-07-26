using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GestureManager : MonoBehaviour
{
    public TMP_Text TextObject;
    public BackController backController;
    public GameObject BlockerGameObject;
    public GameObject MainScene;
    public Toggle toggle;
    public bool constantlyShowBlocker;
    public bool inPosition;


    private bool SucceedBack;
    private Touch touch;
    private Vector2 beginTouchPos, endTouchPos;
    private float initialXPlacement;
    private static bool shownGestureGuide = false;
    private bool playerPrefdoNotShowAgainChecked;



    private void Awake()
    {
        playerPrefdoNotShowAgainChecked = (PlayerPrefs.GetInt("doNotShowAgainChecked") != 0);
        if (!BlockerGameObject)
            return;
        if (!shownGestureGuide)
            BlockerGameObject.SetActive(true);
        else
        {
            BlockerGameObject.SetActive(false);
            return;
        }

        

        if(!playerPrefdoNotShowAgainChecked)//the user checked the do not show again
            BlockerGameObject.SetActive(true);
        else
            BlockerGameObject.SetActive(false);

        Debug.Log("playperPrefBool " + playerPrefdoNotShowAgainChecked);
        if (constantlyShowBlocker)
            BlockerGameObject.SetActive(true);
    }

    private void Start()
    {
        initialXPlacement = Screen.width * .1f;
    }

    private void OnEnable()
    {
        inPosition = false;
        SucceedBack = false;
    }
    public void HideBlocker()
    {
        shownGestureGuide = true;
        BlockerGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainScene.activeInHierarchy)
        {
            return;
        }
        // oni 1 finger on the screen
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beginTouchPos = touch.position;
                    CheckIfRightSpot(beginTouchPos.x);
                    break;

                case TouchPhase.Ended:
                    endTouchPos = touch.position;
                    if (inPosition && endTouchPos.x > Screen.width * 0.4f)
                    {
                        TextObject.text = "back";
                        SucceedBack = true;
                    }
                    inPosition = false;
                    break;
            }
        }

        if (SucceedBack)
        {
            SucceedBack = false;
            backController.GoBackTo();

        }
    }

    void CheckIfRightSpot(float position)
    {
        if (position < initialXPlacement)
        {
            TextObject.text = "in the rite spot";
            inPosition = true;
        }
        else
        {
            TextObject.text = "in the wrong spot";
        }
    }

    public void SetdoNotShowAgainChecked()
    { 
        PlayerPrefs.SetInt("doNotShowAgainChecked", (toggle.isOn ? 1 : 0));
        //Debug.Log("doNotShowAgainChecked " + (PlayerPrefs.GetInt("doNotShowAgainChecked") != 0));
    }
}
