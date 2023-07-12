using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSpawnManager : MonoBehaviour
{
    public GameObject dragTutorial;
    public GameObject pinchTutorial;
    public GameObject twistTutorial;
    public GameObject BlockerGameObject;
    private bool shownDragGuide;
    private bool shownPinchGuide;
    private bool shownTwistGuide;

    private void Awake()
    {
        if (!shownDragGuide && !shownPinchGuide && !shownTwistGuide)
        {
            dragTutorial.SetActive(true);
            pinchTutorial.SetActive(false);
            twistTutorial.SetActive(false);
            BlockerGameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (shownDragGuide && !shownPinchGuide && !shownTwistGuide)
        {
            dragTutorial.SetActive(false);
            pinchTutorial.SetActive(true);
            twistTutorial.SetActive(false);
            BlockerGameObject.SetActive(true);
        }
        if (shownDragGuide && shownPinchGuide && !shownTwistGuide)
        {
            dragTutorial.SetActive(false);
            pinchTutorial.SetActive(false);
            twistTutorial.SetActive(true);
            BlockerGameObject.SetActive(true);
        }
    }

    public void HideDrag() // when drag is shown
    {
        dragTutorial.SetActive(false);
        shownDragGuide = true;
    }
    public void HidePinch() // when pinch is shown
    {
        pinchTutorial.SetActive(false);
        shownPinchGuide = true;
    }
    public void HideBlocker() // when twist is shown
    {
        BlockerGameObject.SetActive(false);
        shownTwistGuide = true;
    }
}
