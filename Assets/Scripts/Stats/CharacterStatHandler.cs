using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStat;

    public CharacterStat CurrentStat {  get; private set; }

    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    public void Awake()
    {
        UpdateStat();
    }

    private void UpdateStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        {
            attackSO = Instantiate(baseStat.attackSO);
        }

        CurrentStat = new CharacterStat { attackSO = attackSO };

        CurrentStat.statChangeType = baseStat.statChangeType;
        CurrentStat.speed = baseStat.speed;
    }
}
