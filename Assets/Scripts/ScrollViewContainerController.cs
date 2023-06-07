using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewContainerController : MonoBehaviour
{
    [SerializeField] private GameObject containerPrefab;
    [SerializeField] private ScrollRect scroll;

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

    public void GenerateContainer()
    {
        GameObject container = Instantiate(containerPrefab, scroll.content);
        RectTransform rectTransformContainer = (RectTransform)containerPrefab.transform;
        float containerHeight = rectTransformContainer.rect.height;
        scroll.content.sizeDelta = new Vector3(scroll.content.sizeDelta.x, scroll.content.sizeDelta.y + containerHeight);
    }
}
