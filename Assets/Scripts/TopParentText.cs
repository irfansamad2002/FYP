using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TopParentText : MonoBehaviour
{
    [SerializeField] private GameObject titleGameObject;

    private TMP_Text topParentText;

    private void Awake()
    {
        topParentText = titleGameObject.GetComponent<TMP_Text>();
    }

    public void ChangeTitleText(string newText)
    {
        topParentText.text = newText;


    }


    private void Update()
    {
        switch (ButtonReferenceManager.Instance.storedDTHButtonID)
        {
            case DTHEnum.DT:
                topParentText.text = "Dental Therapy";
                break;
            case DTHEnum.DH:
                topParentText.text = "Dental Hygiene";
                break;
            case DTHEnum.NONE:
                topParentText.text = " ";
                break;
            default:
                topParentText.text = " ";
                break;
        }
    }



}
