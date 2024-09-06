using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundDisplay : MonoBehaviour
{
    [SerializeField] private Image[] _primColImgs;
    [SerializeField] private Image[] _secColImgs;
    [SerializeField] private Image[] _terColImgs;

    public void SetBackgroundByType(TypeSO primType, TypeSO secType = null)
    {

    }
}
