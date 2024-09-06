using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJsonInterpreter : MonoBehaviour
{
    [SerializeField] private TextAsset _movejson;

    [System.Serializable]
    public class MoveList : IEnumerable<Move>
    {
        public Move[] moves;

        public IEnumerator<Move> GetEnumerator()
        {
            foreach (Move move in moves)
            {
                yield return move;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public MoveList MovesList = new MoveList();

    void Awake()
    {
        MovesList = JsonUtility.FromJson<MoveList>(_movejson.text);
    }
}
