using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("Rotation Buttons")]
    [SerializeField] private GameObject rotationButtons;

    [Header("Text Info")]
    [SerializeField] private TMP_Text RSText;
    [SerializeField] private TMP_Text XYZText;
    [SerializeField] private TMP_Text toolNameText;

    private GameObject spawnedObject;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = true;

    private LeanTwistRotateAxis leanTwistRotateAxis;
    private LeanPinchScale leanPinchScale;

    void Start()
    {
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
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if(leanPinchScale)
        {
            if (leanPinchScale.enabled == true)
            {
                rotationButtons.SetActive(false);
                RSText.text = "Scale";
                XYZText.enabled = false;
            }
            else
            {
                rotationButtons.SetActive(true);
                RSText.text = "Rotate";
                XYZText.enabled = true;

            }
        }
       
    }
    public void OnRSButtonPressed()
    {
        leanPinchScale.enabled = !leanPinchScale.enabled;
        leanTwistRotateAxis.enabled = !leanTwistRotateAxis.enabled;
        AudioPlayer.Instance.PlayAudioOneShot(0);

        Debug.Log("leanPinchScale: " + leanPinchScale.enabled);
        Debug.Log("leanTwistRotateAxis: " + leanTwistRotateAxis.enabled);

    }
    #region rotation button functions
    public void OnXButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(-1f, 0f, 0f));
        XYZText.text = "Current axis: X";
        AudioPlayer.Instance.PlayAudioOneShot(0);
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    public void OnYButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(0f, -1f, 0f));
        XYZText.text = "Current axis: Y";
        AudioPlayer.Instance.PlayAudioOneShot(0);
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    public void OnZButtonPressed()
    {
        spawnedObject.GetComponent<LeanTwistRotateAxis>().ChangeAxis(new Vector3(0f, 0f, 1f));
        XYZText.text = "Current axis: Z";
        AudioPlayer.Instance.PlayAudioOneShot(0);
        //Debug.Log(spawnedObject.GetComponent<LeanTwistRotateAxis>().Axis);
    }
    #endregion

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
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
    }
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
