using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName="typeSO", menuName ="ScriptableObject/TypeSO")]
public class TypeSO : ScriptableObject
{
    public string ename = "";
    public int id;
    public string[] weaknesses;
    public string[] resistances;
    public string[] immunities;
    public Color primColor;
    public Color secColor;
    public Color terColor;
}
