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
        foreach(Image img in _primColImgs)
        {
            img.color = primType.primColor;
        }

        foreach(Image img in _secColImgs)
        {
            if(secType != null)
            {
                img.color = secType.secColor;
            }
            else
            {
                img.color = primType.secColor;
            }
        }

        foreach(Image img in _terColImgs)
        {
            img.color = primType.terColor;
        }
    }
}
