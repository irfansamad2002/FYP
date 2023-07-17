using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolInfoSetColorScrollView : MonoBehaviour
{
    [SerializeField] TopParentColor topParentColor;



    private void OnEnable()
    {
        GetComponent<Image>().color = topParentColor.GetcurrentTopParentColor();
    }
}
