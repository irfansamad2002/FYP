using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New DentistTool", menuName = "DentistTools")]
public class DentistTool : ScriptableObject
{
    [TextArea]
    public string Name;
    public Sprite Icon;

    [TextArea]
    public string Usage;
    [TextArea]
    public string InstrumentGrasp;
    [TextArea]
    public string Instrumentation;

    public Image ToolImage;
}
