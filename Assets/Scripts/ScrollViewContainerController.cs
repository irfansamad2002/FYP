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
        if(dth == DTHEnum.DT)
        {
            int i = 0;
            foreach (DentistTool dentistTools in ButtonReferenceManager.Instance.dtTools)
            {
                //for now just add dht
                GenerateContainerWithTool(i, dentistTools);
                i++;
            }
        }
        else if (dth == DTHEnum.DH)
        {
            int i = 0;
            foreach (DentistTool dentistTools in ButtonReferenceManager.Instance.dhTools)
            {
                //for now just add dht
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
        Debug.Log("On the tool selection");
        ClearContent();
        if(ButtonReferenceManager.Instance)
            LoadTheContent(ButtonReferenceManager.Instance.storedDTHButtonID);
    }

}
