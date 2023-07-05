using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopParentColor : MonoBehaviour
{
    Color defaultColor;
    public Color DTColor;
    public Color DHColor;

    void Awake()
    {
        defaultColor = GetComponent<Image>().color;
    }

    private void Update()
    {

        switch (ButtonReferenceManager.Instance.storedDTHButtonID)
        {
            case DTHEnum.DT:
                GetComponent<Image>().color = DTColor;
                break;
            case DTHEnum.DH:
                GetComponent<Image>().color = DHColor;

                break;
            case DTHEnum.NONE:
                GetComponent<Image>().color = defaultColor;

                break;
            default:
                break;
        }
    }

    public Color GetcurrentTopParentColor()
    {
        switch (ButtonReferenceManager.Instance.storedDTHButtonID)
        {
            case DTHEnum.DT:
                return DTColor;
            case DTHEnum.DH:
                return DHColor;
            case DTHEnum.NONE:
                return defaultColor;
            default:
                return defaultColor;
        }
    }


}
