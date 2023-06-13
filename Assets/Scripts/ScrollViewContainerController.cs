using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollViewContainerController : MonoBehaviour
{
    [SerializeField] private GameObject containerPrefab;
    [SerializeField] private ScrollRect scroll;

    // Start is called before the first frame update

    
    void Start()
    {
        foreach (DentistTool dentistTools in ButtonReferenceManager.Instance.dhTools) {
            GenerateContainerWithTool(dentistTools);
        }
    }
    private void Awake()
    {
        //Debug.Log(ButtonReferenceManager.Instance.GetToolData(0, DTHEnum.DH));
    }
    private void SetupContent()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateContainerWithTool(DentistTool dentistTool)
    {
        GameObject container = Instantiate(containerPrefab, scroll.content);
        container.GetComponent<AppIconContainerController>().Initialize(dentistTool.Icon, dentistTool.Name);
    }
    

    void LoadTools(DTHEnum dthEnum)
    {
        if (dthEnum == DTHEnum.DT) {

        }
        else if (dthEnum == DTHEnum.DH) {
            
        }
        else {
            Debug.Log("Something sus goin on... check if u set the DTHEnum correctly, should be DT or DH and not NONE");
        }
    }
}
