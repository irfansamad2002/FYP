using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssessmentMenuManager : MonoBehaviour
{
    [Header("Top Parent")]
    [SerializeField] private GameObject TopParent;
    [SerializeField] private GameObject HomeButton;
    [SerializeField] private GameObject BackButton;

    [Header("Assessment Menu")]
    [SerializeField] private GameObject AssessmentMenu;
    [SerializeField] private Button Option1Button;
    [SerializeField] private Button Option2Button;
    [SerializeField] private Button Option3Button;
    [SerializeField] private Button Option4Button;

    public SceneChanger sceneChanger;
    void Start()
    {
        TopParent.SetActive(true);
        BackButton.SetActive(true);
        HomeButton.SetActive(false);
        AssessmentMenu.SetActive(true);

        sceneChanger = GetComponent<SceneChanger>();
    }

    public void OnHomeClicked()
    {
        sceneChanger.ChangeToMainScene();
    }

    public void OnOptionClicked()
    {
        // do something
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
