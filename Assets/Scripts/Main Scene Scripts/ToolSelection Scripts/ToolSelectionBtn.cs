using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelectionBtn : MonoBehaviour
{
    private ButtonID buttonID;

    private void Start()
    {
        buttonID = GetComponent<ButtonID>();
    }

    public void SetButtonID()
    {
        ButtonReferenceManager.Instance.storedButtonID = buttonID.buttonID;
    }
}
