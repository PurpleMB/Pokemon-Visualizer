using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchupDisplay : MonoBehaviour
{
    const int _BASEVALUE = 4;

    [SerializeField] private TypeDictionary _typeDic;
    [SerializeField] private TypeNode _nodePrefab;

    [SerializeField] private GridLayoutGroup _weaknessGroup;
    [SerializeField] private GridLayoutGroup _resistanceGroup;
    [SerializeField] private GridLayoutGroup _immunityGroup;

    private TypeSO _primType, _secType;
    private int[] _matchups = new int[18];

    public void DisplayMatchup(string[] types)
    {
        if (types.Length == 0)
        {
            Debug.LogWarning("MatchupDisplay: Invalid typing data recieved");
            return;
        }

        clearMathchups();
        _primType = _typeDic.LookupType(types[0]);
        calculateMatchups(_primType);
        if (types.Length > 1)
        {
            _secType = _typeDic.LookupType(types[1]);
            calculateMatchups(_secType);
        }
        displayWeaknesses();
        displayResistances();
        displayImmunities();
    }

    private void clearMathchups()
    {
        for(int i = 0; i < _matchups.Length; i++) 
        {
            _matchups[i] = _BASEVALUE;
        }
        foreach(Transform child in _weaknessGroup.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _resistanceGroup.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in _immunityGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void calculateMatchups(TypeSO type)
    {
        if (type == null) {
            Debug.LogWarning("MatchupDisplay: Attempting to calculate matchup to null type");
            return;
        }

        foreach(string weakness in type.weaknesses)
        {
            TypeSO weakType = _typeDic.LookupType(weakness);
            if (weakType != null) 
            {
                _matchups[weakType.id] *= 2;
            }
        }

        foreach (string resist in type.resistances)
        {
            TypeSO resistType = _typeDic.LookupType(resist);
            if (resistType != null)
            {
                _matchups[resistType.id] /= 2;
            }
        }

        foreach (string immunity in type.immunities)
        {
            TypeSO immuneType = _typeDic.LookupType(immunity);
            if (immuneType != null)
            {
                _matchups[immuneType.id] *= 0;
            }
        }
    }

    private void displayWeaknesses()
    {
        for (int typeId = 0; typeId < _matchups.Length; typeId++)
        {
            if (_matchups[typeId] > _BASEVALUE)
            {
                TypeNode node = Instantiate<TypeNode>(_nodePrefab, _weaknessGroup.transform);
                node.SetDisplayedType(_typeDic.LookupType(typeId));
            }
        }
    }

    private void displayResistances() 
    {
        for (int typeId = 0; typeId < _matchups.Length; typeId++)
        {
            if (_matchups[typeId] < _BASEVALUE && _matchups[typeId] != 0)
            {
                TypeNode node = Instantiate<TypeNode>(_nodePrefab, _resistanceGroup.transform);
                node.SetDisplayedType(_typeDic.LookupType(typeId));
            }
        }
    }

    private void displayImmunities() 
    {
        for (int typeId = 0; typeId < _matchups.Length; typeId++)
        {
            if (_matchups[typeId] == 0)
            {
                TypeNode node = Instantiate<TypeNode>(_nodePrefab, _immunityGroup.transform);
                node.SetDisplayedType(_typeDic.LookupType(typeId));
            }
        }
    }
}
