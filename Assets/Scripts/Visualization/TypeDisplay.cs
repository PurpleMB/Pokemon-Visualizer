using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDisplay : MonoBehaviour
{
    [SerializeField] private TypeNode _primTypeNode;
    [SerializeField] private TypeNode _secTypeNode;

    public void SetDisplayedTyping(string[] types)
    {
        if (types.Length == 0) {
            Debug.LogWarning("TypeDisplay: Invalid typing data recieved");
            return; 
        }

        _primTypeNode.SetDisplayedType(types[0]);

        if(types.Length > 1) 
        {
            _secTypeNode.gameObject.SetActive(true);
            _secTypeNode.SetDisplayedType(types[1]);
        } else
        {
            _secTypeNode.gameObject.SetActive(false);
        }
    }
}
