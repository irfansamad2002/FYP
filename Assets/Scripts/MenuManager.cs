using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [Header("Top Parent")]
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Main Menu")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private Button DentalTherapyButton;
    [SerializeField] private Button DentalHealthButton;

    //[Header("Dental Health and Therapy")]
    //[SerializeField] private GameObject Menu;
    //[SerializeField] private Button ItemsButton;
    //[SerializeField] private Button AssessmentButton;
    //[SerializeField] private Button ScanButton;

    [Header("Selection Screen")]
    [SerializeField] private GameObject SelectionMenu;
    [SerializeField] private Button ToolsButton;
    [SerializeField] private Button AssessmentButton;
    [SerializeField] private Button ScanButton;

    [Header("Tool Info")]
    [SerializeField] private GameObject ToolInfoMenu;
    [SerializeField] private TMP_Text InfoText;
    [SerializeField] private Button ToolAssessmentButton;
    [SerializeField] private Button DemoVideoButton;

    [Header("Assessment")]
    [SerializeField] private GameObject AssessmentMenu;

    //[Header("Dental Health")]
    //[SerializeField] private GameObject DHMenu;
    //[SerializeField] private Button DHItemsButton;
    //[SerializeField] private Button DHAssessmentButton;
    //[SerializeField] private Button DHScanButton;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AssessmentMenu.active == false)
        {
            Debug.Log("Lol");

        }
    }
}
