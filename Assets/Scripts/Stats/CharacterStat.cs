using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatChangeType
{
    Add,
    Multiple,
    Override
}

[System.Serializable]

public class CharacterStat
{
    public StatChangeType statChangeType;
    [Range(1f, 20f)] public float speed;
    public AttackSO attackSO;

}
