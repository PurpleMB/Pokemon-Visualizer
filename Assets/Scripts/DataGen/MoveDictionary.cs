using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveDictionary : MonoBehaviour
{
    private MoveJsonInterpreter _moveJson;

    public Dictionary<string, Move> MoveNameDict = new Dictionary<string, Move>();

    // Start is called before the first frame update
    private void Start()
    {
        _moveJson = GetComponent<MoveJsonInterpreter>();
        foreach (Move move in _moveJson.MovesList)
        {

            MoveNameDict.Add(move.ename, move);
        }
        Debug.Log("Move Dictionary size at Start: " + MoveNameDict.Count);
    }

    public Move GetMove(string name)
    {
        return MoveNameDict[name];
    }

    public Move GetMove(int id)
    {
        id = Mathf.Clamp(id, 1, _moveJson.MovesList.Count());
        return _moveJson.MovesList.ElementAt(id - 1);
    }
}
