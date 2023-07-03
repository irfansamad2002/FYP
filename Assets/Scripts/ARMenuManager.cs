using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMenuManager : MonoBehaviour
{

    [Header("Top Parent")]
    [SerializeField] private GameObject TopParent;
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Tool Menu")]
    [SerializeField] private GameObject ToolMenu;
    [SerializeField] private Button ToolInfoButton;

    [Header("Tool Info Page")]
    [SerializeField] private GameObject ToolInfoMenu;
    [SerializeField] private Button DemoVideoButton;

    public SceneChanger sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        //TopParent.SetActive(true);
        //HomeButton.SetActive(false);
        //BackButton.SetActive(true);
        //ToolMenu.SetActive(false);
        //ToolInfoMenu.SetActive(true);
    }

    public void OnHomeClicked()
    {
        sceneChanger.ChangeToMainScene();
    }

    public void OnToolFound()
    {
        ToolMenu.SetActive(true);
    }
    
    public void OnToolInfoClicked()
    {
        ToolMenu.SetActive(false);
        ToolInfoMenu.SetActive(true);
        HomeButton.SetActive(true);
    }

    public void OnDemoVideoClicked()
    {
        ToolInfoMenu.SetActive(false);
        HomeButton.SetActive(false);
        // change scene to demo video scene
        sceneChanger.ChangeToVideoScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
