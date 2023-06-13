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
    //[SerializeField] private GameObject nameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        });
    }
}
