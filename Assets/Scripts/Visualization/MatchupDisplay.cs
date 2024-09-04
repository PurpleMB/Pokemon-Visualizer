using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchupDisplay : MonoBehaviour
{
    [SerializeField] private TypeDictionary _typeDic;
    [SerializeField] private TypeNode _nodePrefab;

    [SerializeField] private GridLayoutGroup _weaknessGroup;
    [SerializeField] private GridLayoutGroup _resistancesGroup;
    [SerializeField] private GridLayoutGroup _immunitiesGroup;

    private TypeScriptable _primType, _secType;
    //2^(value-3) == damage multiplier, unless value is 0
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
        if (types.Length > 1)
        {
            _secType = _typeDic.LookupType(types[1]);
        }
    }

    private void clearMathchups()
    {
        for(int i = 0; i < _matchups.Length; i++) 
        {
            _matchups[i] = 3;
        }
    }

    private void calculateMatchups(TypeScriptable type)
    {
        if (type == null) {
            Debug.LogWarning("MatchupDisplay: Attempting to calculate matchup to null type");
            return;
        }

        foreach(string weakness in type.weaknesses)
        {
            TypeScriptable weakType = _typeDic.LookupType(weakness);
            if (weakType == null) 
            {
                _matchups[weakType.id] += 1;
            }
        }

        foreach (string resist in type.resistances)
        {
            TypeScriptable resistType = _typeDic.LookupType(resist);
            if (resistType == null)
            {
                _matchups[resistType.id] -= 1;
            }
        }

        foreach (string immunity in type.immunities)
        {
            TypeScriptable immuneType = _typeDic.LookupType(immunity);
            if (immuneType == null)
            {
                _matchups[immuneType.id] = 0;
            }
        }
    }
}
