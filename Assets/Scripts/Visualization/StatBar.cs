using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Slider _statBar;
    [SerializeField] private TextMeshProUGUI _statText;
    [SerializeField] private Gradient _statGradient;

    private int _displayedStat = -1;

    public void SetStat(int stat)
    {
        _displayedStat = stat;

        _statBar.value = _displayedStat;
        _statBar.targetGraphic.color = _statGradient.Evaluate(_displayedStat / 255.0f);

        _statText.text = _displayedStat.ToString();
    }
}
