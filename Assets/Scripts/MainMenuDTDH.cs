using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDTDH : MonoBehaviour
{
    const string TAG_MENUMGR = "MenuTag";

    [SerializeField] PlayAnimationClick playAnimationClick;
    [SerializeField] ButtonID buttonID;

    MenuManager menuManager;

    public void ClickedDTorDH()
    {
        //PlayAnimationClick.Clicked();
        //animationDuration = PlayAnimationClick.animationDuration;
        //buttonID.AssignDTHButtonID();
        //buttonID.AssignBackButtonID();
        //menuManager.OnDHorDTClicked();
        StartCoroutine(ClickedBtn());
    }
    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.FindGameObjectWithTag(TAG_MENUMGR).GetComponent<MenuManager>();
    }

    IEnumerator ClickedBtn()
    {
        playAnimationClick.Clicked();
        yield return new WaitForSeconds(playAnimationClick.GetAnimationDuration());
        
        buttonID.AssignDTHButtonID();
        buttonID.AssignBackButtonID();
        menuManager.OnDHorDTClicked();


    }


}
