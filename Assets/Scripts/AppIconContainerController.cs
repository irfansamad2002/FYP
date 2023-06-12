using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AppIconContainerController : MonoBehaviour
{
    [SerializeField] private Image imageIcon;
    [SerializeField] private TMP_Text textMeshPro;

    //[SerializeField] private GameObject nameDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Sprite image, string toolName)
    {
        imageIcon.sprite = image;
        textMeshPro.text = toolName;
    }
}
