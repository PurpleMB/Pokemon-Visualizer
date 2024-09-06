using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TypeDictionary : MonoBehaviour
{
    [SerializeField] private TypeSO[] _types;
    private Dictionary<string, TypeSO> _typesDic = new Dictionary<string, TypeSO>();

    private void Awake()
    {
        foreach (var type in _types)
        {
            _typesDic.Add(type.ename, type);
        }
    }

    public void LookupPokemomTypes(Pokemon poke,ref TypeSO primType,ref TypeSO secType)
    {
        if (poke == null)
        {
            return;
        }

        string[] types = poke.type;
        primType = _typesDic[types[0]];
        if(types.Length > 1)
        {
            secType = _typesDic[types[1]];
        }
    }

    public TypeSO LookupType(string typeName)
    {
        if(_typesDic.ContainsKey(typeName))
        {
            return _typesDic[typeName];
        }
        Debug.LogWarning("TypeDictionary: No type found for given name");
        return _typesDic["???"];
    }

    public TypeSO LookupType(int typeId) 
    { 
        if(typeId >= 0 && typeId < _types.Length)
        {
            return _types[typeId];
        }
        Debug.LogWarning("TypeDictionary: No type found for given ID");
        return _typesDic["???"];
    }
}
