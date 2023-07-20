using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolInfoBtn : MonoBehaviour
{
    ButtonID buttonID;


    // Start is called before the first frame update
    void Start()
    {
        buttonID = GetComponent<ButtonID>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonID()
    {
        ButtonReferenceManager.Instance.storedButtonID = buttonID.buttonID;
    }
}
