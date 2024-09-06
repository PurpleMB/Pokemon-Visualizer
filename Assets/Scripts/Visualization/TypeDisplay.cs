using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TypeDisplay : MonoBehaviour
{
    [SerializeField] private TypeDictionary _typeDic;
    [SerializeField] private TypeNode _primTypeNode;
    [SerializeField] private TypeNode _secTypeNode;

    private TypeSO _primType;
    private TypeSO _secType;

    public void SetDisplayedTyping(string[] types)
    {
        if (types.Length == 0) {
            Debug.LogWarning("TypeDisplay: Invalid typing data recieved");
            return;
        }

        _primType = _typeDic.LookupType(types[0]);
        _primTypeNode.SetDisplayedType(_primType);
        if(types.Length > 1) 
        {
            _secType = _typeDic.LookupType(types[1]);
            _secTypeNode.gameObject.SetActive(true);
            _secTypeNode.SetDisplayedType(_secType);
        } else
        {
            _secTypeNode.gameObject.SetActive(false);
        }
    }
}
