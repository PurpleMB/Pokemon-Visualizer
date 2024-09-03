using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDictionary : MonoBehaviour
{
    [SerializeField] private TypeScriptable[] Types;

    public TypeScriptable LookupType(string typeName)
    {
        foreach (var type in Types)
        {
            if(type.ename == typeName) return type;
        }
        Debug.LogWarning("TypeDictionary: No type found for given name");
        return null;
    }
}
