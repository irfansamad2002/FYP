using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
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

    public GameObject dentalItem;

    public VideoClip videoClip;
}
