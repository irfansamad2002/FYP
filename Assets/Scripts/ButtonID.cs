using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonID : MonoBehaviour
{

    public ButtonENUM buttonID;

    public void AssignBackButtonID()
    {
        ButtonReferenceManager.Instance.storedButtonID = buttonID;
    }
}
