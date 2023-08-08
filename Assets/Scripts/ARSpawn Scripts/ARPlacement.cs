using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Lean.Touch;
using TMPro;

public class ARPlacement : MonoBehaviour
{
    public GameObject placedInstrument;
    public GameObject placementIndicator;

    [Header("Rotate/Scale Button")]
    [SerializeField] private GameObject RSButton;
    [SerializeField] private TMP_Text RSButtonText;
    [SerializeField] private Sprite rotateSprite;
    [SerializeField] private Sprite scaleSprite;

    [Header("Rotation Buttons")]
    [SerializeField] private GameObject rotationButtons;
    [SerializeField] private GameObject rotateXButton;
    [SerializeField] private GameObject rotateYButton;
    [SerializeField] private GameObject rotateZButton;

    [Header("Button Colours")]
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color selectedColor;

    [Header("Text Info")]
    [SerializeField] private TMP_Text toolNameText;

    private GameObject spawnedObject;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = true;

    private LeanTwistRotateAxis leanTwistRotateAxis;
    private LeanPinchScale leanPinchScale;

    void Start()
    {
        // get appropriate 3d model and name based on DT/DH
        if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DT)
        {
            placedInstrument = ButtonReferenceManager.Instance.dtTools[ButtonReferenceManager.Instance.storedIndex].dentalItem;
            toolNameText.text = ButtonReferenceManager.Instance.dtTools[ButtonReferenceManager.Instance.storedIndex].Name;
        }
        else if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DH)
        {
            placedInstrument = ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex].dentalItem;
            toolNameText.text = ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex].Name;
        }

        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        Debug.Log(placedInstrument);

        

        // start with rotate first
        RSButton.SetActive(true);
        rotationButtons.SetActive(true);
    }



    // need to update placement indicator, placement pose and spawn 
    void Update()
    {
        // if no object is spawned + placement indicator is at valid pos + user tapped screen, spawn 3d object in AR
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        // update placement indicator pos every frame
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if(leanPinchScale)
        {
            // if scaling enabled, rotate scale button sprite change to scale icon
            if (leanPinchScale.enabled == true)
            {
                rotationButtons.SetActive(false);
                RSButton.GetComponent<Image>().sprite = scaleSprite;
            }
            // if rotation enabled, rotate scale button sprite change to rotate icon
            else
            {
                rotationButtons.SetActive(true);
                RSButton.GetComponent<Image>().sprite = rotateSprite;

            }
        }
       
    }

    // swap between rotating and scaling when pressing button
    public void OnRSButtonPressed()
    {
        leanPinchScale.enabled = !leanPinchScale.enabled;
        leanTwistRotateAxis.enabled = !leanTwistRotateAxis.enabled;

        Debug.Log("leanPinchScale: " + leanPinchScale.enabled);
        Debug.Log("leanTwistRotateAxis: " + leanTwistRotateAxis.enabled);

    }
    #region rotation button functions
    public void OnXButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(-1f, 0f, 0f));
        rotateXButton.GetComponent<Image>().color = selectedColor;
        selectedColor.a = 255f;
        rotateYButton.GetComponent<Image>().color = defaultColor;
        rotateZButton.GetComponent<Image>().color = defaultColor;
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    public void OnYButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(0f, -1f, 0f));
        rotateXButton.GetComponent<Image>().color = defaultColor;
        rotateYButton.GetComponent<Image>().color = selectedColor;
        selectedColor.a = 255f;
        rotateZButton.GetComponent<Image>().color = defaultColor;
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    public void OnZButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(0f, 0f, 1f));
        rotateXButton.GetComponent<Image>().color = defaultColor;
        rotateYButton.GetComponent<Image>().color = defaultColor;
        rotateZButton.GetComponent<Image>().color = selectedColor;
        selectedColor.a = 255f;
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    #endregion

    // update placement indicator position 
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        // place placement indicator in middle of screen
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }

    // spawn 3d model
    void ARPlaceObject()
    {
        Debug.Log("ARPlaceObject");
        spawnedObject = Instantiate(placedInstrument, PlacementPose.position, PlacementPose.rotation);

        leanTwistRotateAxis = spawnedObject.GetComponent<LeanTwistRotateAxis>();
        leanPinchScale = spawnedObject.GetComponent<LeanPinchScale>();

        // start with rotate
        leanPinchScale.enabled = false;
        leanTwistRotateAxis.enabled = true;
    }
}
