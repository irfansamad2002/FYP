using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GestureManager : MonoBehaviour
{
    public TMP_Text TextObject;
    public BackController backController;
    public GameObject BlockerGameObject;
   
    private bool SucceedBack;
    private Touch touch;
    private Vector2 beginTouchPos, endTouchPos;
    private float initialXPlacement;
    private bool inPosition;
    private bool shownGestureGuide;

    private void Awake()
    {
        if(!shownGestureGuide)
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
        BlockerGameObject.SetActive(false);
        shownGestureGuide = true;
    }

    // Update is called once per frame
    void Update()
    {

        // oni 1 finger on the screen
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            //TextObject.text = touch.position.x.ToString();


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
}
