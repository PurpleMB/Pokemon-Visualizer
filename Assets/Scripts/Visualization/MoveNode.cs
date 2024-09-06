using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveNode : MonoBehaviour
{
    [SerializeField] private Image _outerImg;
    [SerializeField] private Image _innerImg;
    [SerializeField] private TextMeshProUGUI _moveName;

    public void SetDisplayedMove(Move move, TypeSO type)
    {
        _outerImg.color = type.primColor;
        _innerImg.color = type.secColor;
        _moveName.text = move.ename;
    }
}