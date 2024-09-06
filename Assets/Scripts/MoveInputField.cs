using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputField : MonoBehaviour
{
    [SerializeField] private Visualizer _visualizer;
    [SerializeField] private int _moveSlot = -1;

    public void OnMoveEntered(string ename)
    {
        if (_visualizer != null)
        {
            if (!_visualizer.VisualizeMove(ename.ToLower(), _moveSlot))
            {
                //TODO: Behavior for when move input is invalid
            }
        }
    }
}
