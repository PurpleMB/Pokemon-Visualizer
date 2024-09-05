using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputField : MonoBehaviour
{
    [SerializeField] private MoveDictionary _mDic;
    [SerializeField] private Visualizer _visualizer;
    [SerializeField] private int _moveSlot = -1;

    public void OnMoveEntered(string ename)
    {
        if (_visualizer != null)
        {
            Move identifiedMove = _mDic.GetMove(ename);

            if (identifiedMove != null)
            {
                Debug.Log("MoveInputField: Input move successfuly found " + identifiedMove.ename);
                if (_visualizer != null)
                {
                    _visualizer.SetVisualizedMove(identifiedMove, _moveSlot);
                }
            }
        }
    }
}
