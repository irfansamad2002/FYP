using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollViewContainerController : MonoBehaviour
{
    [SerializeField] private GameObject containerPrefab;
    [SerializeField] private ScrollRect scroll;
    [SerializeField] private Transform contentTransform;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void LoadTheContent(DTHEnum dth)
    {
        ClearContent();
        if (dth == DTHEnum.DT)
        {
            Debug.Log("loading for dt");
            int i = 0;
            foreach (DentistTool dentistTools in ButtonReferenceManager.Instance.dtTools)
            {
                Debug.Log("Loaded: " + dentistTools.name + "Index: " + i);
                GenerateContainerWithTool(i, dentistTools);
                i++;
            }
        }
        else if (dth == DTHEnum.DH)
        {
            int i = 0;
            Debug.Log("loading for dh");

            foreach (DentistTool dentistTools in ButtonReferenceManager.Instance.dhTools)
            {
                GenerateContainerWithTool(i, dentistTools);
                i++;
            }
        }
        else
        {
            Debug.Log("trying to generate content with NONE as DTHEnum");
        }

    }

    void GenerateContainerWithTool(int index, DentistTool dentistTool)
    {
        GameObject container = Instantiate(containerPrefab, scroll.content);
        container.GetComponent<AppIconContainerController>().Initialize(index, dentistTool.Icon, dentistTool.Name);
    }
    
    public void ClearContent()
    {
        foreach (Transform child in contentTransform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void OnEnable()
    {
        ClearContent();
        if (ButtonReferenceManager.Instance)
        {
            //Debug.Log("OnEnable tool selection" + ButtonReferenceManager.Instance.storedDTHButtonID);
            LoadTheContent(ButtonReferenceManager.Instance.storedDTHButtonID);

        }
    }

    private void OnDisable()
    {
        //Debug.Log("OnDisable tool selection" + ButtonReferenceManager.Instance.storedDTHButtonID);
        
        ClearContent();

    }

}
