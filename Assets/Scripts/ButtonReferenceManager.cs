using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonENUM
{
    MAINSCENE,
    TOOLSELECTION,
    ARBIT,
    TOOLINFO,
    ASSESSMENT,
    DEMOVID
}

public enum DTHEnum
{
    DT,
    DH,
    NONE
}

public class ButtonReferenceManager : MonoBehaviour
{
    public static ButtonReferenceManager Instance { get; private set; }
    public ButtonENUM storedButtonID;
    public DTHEnum storedDTHButtonID;
    public int storedIndex;
    public DentistTool[] dtTools;
    public DentistTool[] dhTools;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        LoadToolsDatabases();

    }

    void LoadToolsDatabases()
    {
        dhTools = Resources.LoadAll<DentistTool>("AllTheTools/DH");
        dtTools = Resources.LoadAll<DentistTool>("AllTheTools/DT");

        Debug.Log("loaded the databases");
    }

}
