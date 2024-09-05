using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDisplay : MonoBehaviour
{
    [SerializeField] private MoveNode[] _moveSlots;

    public void DisplayMoveInSlot(Move move, TypeScriptable type ,int slot)
    {
        if (move == null || (slot < 0 || slot > _moveSlots.Length - 1))
        {
            return;
        }

        _moveSlots[slot].SetDisplayedMove(move, type);
    }
}
