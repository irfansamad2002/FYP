using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DentistTool", menuName = "DentistTools")]
public class DentistTool : ScriptableObject
{
    public string Name;
    public Sprite Icon;

    public string Usage;
    public string InstrumentGrasp;
    public string Instrumentation;

}
