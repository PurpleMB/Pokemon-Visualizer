using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private StatBar _healthBarGroup;
    [SerializeField] private StatBar _attackBarGroup;
    [SerializeField] private StatBar _defenseBarGroup;
    [SerializeField] private StatBar _spAtkBarGroup;
    [SerializeField] private StatBar _spDefBarGroup;
    [SerializeField] private StatBar _speedBarGroup;

    [SerializeField] private TextMeshProUGUI _statTotalTMP;

    private int _bst = -1;

    public void SetStatDisplay(BaseStats bs)
    {
        _bst = 0;

        _healthBarGroup.SetStat(bs.HP);
        _bst += bs.HP;

        _attackBarGroup.SetStat(bs.Attack);
        _bst += bs.Attack;

        _defenseBarGroup.SetStat(bs.Defense);
        _bst += bs.Defense;

        _spAtkBarGroup.SetStat(bs.SpecialAttack);
        _bst += bs.SpecialAttack;

        _spDefBarGroup.SetStat(bs.SpecialDefense);
        _bst += bs.SpecialDefense;

        _speedBarGroup.SetStat(bs.Speed);
        _bst += bs.Speed;

        _statTotalTMP.text = $"Base Stat Total: {_bst}";
    }
}
