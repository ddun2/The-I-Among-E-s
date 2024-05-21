using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "IAEController/Attack/Default", order = 0)]

public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public string projectileNameTag;
    public float duration;
    public float spread;
    public float speed;
    public float delay;
    public float multipleShotAngle;
    public int numberOfProjectilePerShot;
    
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockBack;
    public float knockBackPower;
    public float knockBackTime;

}
