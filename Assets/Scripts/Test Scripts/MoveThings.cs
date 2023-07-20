using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThings : MonoBehaviour
{
    public GameObject MainMenuGameObject;
    public List<GameObject> listOfPanels = new List<GameObject>();
    public Vector2 InitialPosition;
    public Vector2 CurrentPosition;
    public Vector2 LastPosition;


    private Touch touch;
    private GestureManager gestureManager;


    private void Start()
    {
        gestureManager = GetComponent<GestureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // oni 1 finger on the screen
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (gestureManager.inPosition)
                        InitialPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    if (gestureManager.inPosition)
                        CurrentPosition = touch.position - InitialPosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    CurrentPosition = new Vector2(0, 0);
                    break;
                case TouchPhase.Canceled:
                    CurrentPosition = new Vector2(0, 0);
                    break;
                default:
                    break;
            }
            if (CheckWhichPanelActive() != MainMenuGameObject)
            {
                CheckWhichPanelActive().GetComponent<RectTransform>().anchoredPosition = new Vector2(CurrentPosition.x * .25f, CheckWhichPanelActive().GetComponent<RectTransform>().anchoredPosition.y);

            }



        }
      
    }

    GameObject CheckWhichPanelActive()
    {
        for (int i = 0; i < listOfPanels.Count; i++)
        {
            if (listOfPanels[i].activeInHierarchy)
            {
                return listOfPanels[i];
            }
        }
        return listOfPanels[0];
    }
}
