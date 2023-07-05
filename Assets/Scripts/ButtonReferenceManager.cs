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
    // Start is called before the first frame update
    void Start()    
    {
    }

    void LoadToolsDatabases()
    {
        dhTools = Resources.LoadAll<DentistTool>("AllTheTools/DH");
        dtTools = Resources.LoadAll<DentistTool>("AllTheTools/DT");

        Debug.Log("loaded the databases");
    }

    //public DentistTool GetToolData(int index, DTHEnum DTHenum)
    //{
    //    if (DTHenum == DTHEnum.DT) 
    //    {
    //        return dtTools[index];
    //    }
    //    else if(DTHenum == DTHEnum.DH)
    //    {
    //        return dhTools[index];
    //    }
    //    else {
    //        return dtTools[index];//Should show error or smth..
    //    }

    //}

    //public DentistTool[] GetDHorDTList(DTHEnum DTHenum)
    //{
    //    switch (DTHenum) {
    //    case DTHEnum.DT:
    //        return dtTools;
    //    case DTHEnum.DH:
    //        return dhTools;
    //    case DTHEnum.NONE://Should not be none
    //        return dtTools;
    //    default://Should not be none
    //        return dtTools;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
