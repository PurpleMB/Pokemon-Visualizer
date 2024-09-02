using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJsonInterpreter : MonoBehaviour
{
    [SerializeField] private TextAsset _movejson;

    [System.Serializable]
    public class Move
    {
        public int accuracy;
        public string category;
        public string ename;
        public int id;
        public int power;
        public int pp;
        public string type;
    }

    [System.Serializable]
    public class MoveList
    {
        public Move[] moves;
    }

    public MoveList moveList = new MoveList();

    // Start is called before the first frame update
    void Awake()
    {
        moveList = JsonUtility.FromJson<MoveList>(_movejson.text);
    }
}
