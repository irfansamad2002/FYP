using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AppIconContainerController : MonoBehaviour
{
    [SerializeField] private Image imageIcon;
    [SerializeField] private TMP_Text textMeshPro;
    private int index;
    private Button button;
    private MenuManager menuManager;
    //[SerializeField] private GameObject nameDisplay;
    // Start is called before the first frame update

    private void Start()
    {
        menuManager = GameObject.FindGameObjectWithTag("MenuTag").GetComponent<MenuManager>();
    }
    public void Initialize(int index,Sprite image, string toolName)
    {
        this.index = index;
        imageIcon.sprite = image;
        textMeshPro.text = toolName;
        name = toolName;
        SetupButtons();
    }

    private void SetupButtons()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            ButtonReferenceManager.Instance.storedIndex = index;
            ButtonReferenceManager.Instance.storedButtonID = ButtonENUM.TOOLSELECTION;
            menuManager.OnToolClicked();
            
        });
    }
}
