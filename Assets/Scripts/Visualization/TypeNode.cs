using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeNode : MonoBehaviour
{
    [SerializeField] private Image _outerImg;
    [SerializeField] private Image _innerImg;
    [SerializeField] private TextMeshProUGUI _typeText;

    public void SetDisplayedType(string typeName)
    {
        TypeScriptable type = TypeDictionary.Instance.LookupType(typeName);

        _outerImg.color = type.primColor;
        _innerImg.color = type.secColor;
        _typeText.text = type.ename;
    }
}
