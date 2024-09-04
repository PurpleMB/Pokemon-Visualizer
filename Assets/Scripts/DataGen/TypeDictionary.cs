using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDictionary : MonoBehaviour
{
    [SerializeField] private TypeScriptable[] _types;

    public TypeScriptable LookupType(string typeName)
    {
        foreach (var type in _types)
        {
            if(type.ename == typeName) return type;
        }
        Debug.LogWarning("TypeDictionary: No type found for given name");
        return null;
    }

    public TypeScriptable LookupType(int typeId) 
    { 
        return _types[typeId];
    }
}
