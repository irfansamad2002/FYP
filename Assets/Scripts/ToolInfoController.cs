using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToolInfoController : MonoBehaviour
{
    [SerializeField] private TMP_Text toolNameText;
    [SerializeField] private TMP_Text toolDescText;
    [SerializeField] private Image toolImage;

    private void Start()
    {
        //LoadContent(ButtonReferenceManager.Instance.dhTools[0]);
    }

    private void OnEnable()
    {
        //LoadContent(ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex]);
        if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DH)
        {
            LoadContent(ButtonReferenceManager.Instance.dhTools[ButtonReferenceManager.Instance.storedIndex]);
        }
        else if (ButtonReferenceManager.Instance.storedDTHButtonID == DTHEnum.DT)
        {
            LoadContent(ButtonReferenceManager.Instance.dtTools[ButtonReferenceManager.Instance.storedIndex]);
        }

    }
    public void LoadContent(DentistTool dentistTool)
    {
        toolNameText.text = dentistTool.Name;
        toolDescText.text = dentistTool.Usage + "\n" + dentistTool.Instrumentation + "\n" + dentistTool.InstrumentGrasp;
        toolImage.sprite = dentistTool.Icon;
        //Debug.Log("ToolInfo loaded with " + dentistTool.Name);
    }

  
}
