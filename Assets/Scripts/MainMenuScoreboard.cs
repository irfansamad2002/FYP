using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScoreboard : MonoBehaviour
{
    const string TAG_MENUMGR = "MenuTag";
    [SerializeField] PlayAnimationClick playAnimationClick;
    MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.FindGameObjectWithTag(TAG_MENUMGR).GetComponent<MenuManager>();
    }
    public void ClickedScoreboard()
    {
        StartCoroutine(ClickedBtn());
    }
    IEnumerator ClickedBtn()
    {
        playAnimationClick.Clicked();
        yield return new WaitForSeconds(.5f);

        menuManager.OnScoresClicked();
        yield return null;
    }


}
