using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MoveJsonInterpreter))]
public class MoveDatabase : Database<Move>
{
    private MoveJsonInterpreter _moveJson;

    protected override void fillDics()
    {
        _moveJson = GetComponent<MoveJsonInterpreter>();

        _nameDict.Clear();
        _idDict = new List<Move>();
        foreach (Move move in _moveJson.MovesList)
        {
            _nameDict.Add(move.ename.ToLower(), move);
            _idDict.Add(move);
        }
    }
}
