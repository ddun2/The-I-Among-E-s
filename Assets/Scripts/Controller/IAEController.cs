using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;
    protected CharacterStatHandler stats { get; private set; }

    protected bool IsAttacking {  get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if ( IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0.0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
            Debug.Log("¤·¤·");
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
