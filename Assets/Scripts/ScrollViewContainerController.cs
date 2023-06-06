using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewContainerController : MonoBehaviour
{
    public GameObject containerPrefab;
    public ScrollRect scroll;

    // Start is called before the first frame update
    void Start()
    {
        SetupContent();
        
    }

    private void SetupContent()
    {
        scroll.content.sizeDelta = new Vector3(scroll.content.sizeDelta.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
