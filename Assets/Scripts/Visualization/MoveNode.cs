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
    [SerializeField] private Image _moveCatBar;
    [SerializeField] private Image _moveCatIcon;

    [SerializeField] private Color _physBarCol;
    [SerializeField] private Color _physIconCol;
    [SerializeField] private Sprite _physImg;
    [SerializeField] private Color _specBarCol;
    [SerializeField] private Color _specIconCol;
    [SerializeField] private Sprite _specImg;
    [SerializeField] private Color _statBarCol;
    [SerializeField] private Color _statIconCol;
    [SerializeField] private Sprite _statImg;
    [SerializeField] private Color _nullBarCol;
    [SerializeField] private Color _nullIconCol;

    public void SetDisplayedMove(Move move, TypeSO type)
    {
        _outerImg.color = type.primColor;
        _innerImg.color = type.terColor;
        _moveName.text = move.ename;

        switch(move.category) 
        {
            case "Physical":
                _moveCatBar.color = _physBarCol;
                _moveCatIcon.color = _physIconCol;
                _moveCatIcon.sprite = _physImg;
                break;
            case "Special":
                _moveCatBar.color = _specBarCol;
                _moveCatIcon.color = _specIconCol;
                _moveCatIcon.sprite = _specImg;
                break;
            case "Status":
                _moveCatBar.color = _statBarCol;
                _moveCatIcon.color = _statIconCol;
                _moveCatIcon.sprite = _statImg;
                break;
            default:
                _moveCatBar.color = _nullBarCol;
                _moveCatIcon.color = _nullIconCol;
                _moveCatIcon.sprite = null;
                break;
        }
    }
}