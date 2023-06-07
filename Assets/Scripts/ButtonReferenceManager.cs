using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonENUM
{
    SELECTIONSCREEN,
    TOOLSELECTION,
    ARBIT,
    TOOLINFO,
    DEMOVIDEO,
    ASSESSMENT
}

public class ButtonReferenceManager : MonoBehaviour
{
    public static ButtonReferenceManager Instance;
    public ButtonENUM storedButtonID;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (Instance != null)
        {
            Destroy(gameObject);
        }
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
