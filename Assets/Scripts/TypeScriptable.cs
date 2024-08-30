using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="typeSO", menuName ="ScriptableObject/TypeSO")]
public class TypeScriptable : ScriptableObject
{
    public string ename = "";
    public string[] weaknesses;
    public string[] resistances;
    public string[] immunities;
}
