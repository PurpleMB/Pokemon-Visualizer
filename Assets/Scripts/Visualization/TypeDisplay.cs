using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TypeDisplay : MonoBehaviour
{
    [SerializeField] private TypeNode _primTypeNode;
    [SerializeField] private TypeNode _secTypeNode;

    public void SetDisplayedTyping(TypeSO primType, TypeSO secType = null)
    {
        _primTypeNode.SetDisplayedType(primType);
        if(secType != null) 
        {
            _secTypeNode.gameObject.SetActive(true);
            _secTypeNode.SetDisplayedType(secType);
        } 
        else
        {
            _secTypeNode.gameObject.SetActive(false);
        }
    }
}
