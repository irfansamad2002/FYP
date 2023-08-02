using UnityEngine;
using UnityEngine.UI;


public class ItemUIContainerController : MonoBehaviour
{
    public Text ItemName, ItemDescription;
    public Image ItemPortrait;


    public void Init(string name, string description, Sprite image)
    {
        ItemName.text = name;
        ItemDescription.text = description;
        ItemPortrait.sprite = image;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
