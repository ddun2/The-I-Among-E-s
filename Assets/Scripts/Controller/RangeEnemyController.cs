using System;
using UnityEngine;

public class RangeEnemyController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 100f;
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;

    private int layerMaskTarget;

    protected override void Start()
    {
        base.Start();
        layerMaskTarget = stats.CurrentStat.attackSO.target;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, directionToTarget);
    }

    private void UpdateEnemyState(float distanceToTarget, Vector2 directionToTarget)
    {
        IsAttacking = false;
        if (distanceToTarget < followRange) // 사정 거리 내일 때
        {
            CheckIfNear(distanceToTarget, directionToTarget);   // 공격 범위인지 추적 범위인지 재확인
        }
    }

    private void CheckIfNear(float distance, Vector2 direction)
    {
        if (distance <= shootRange)
        {
            TryShootAtTarget(direction);    // 공격 범위 내면 공격
        }
        else
        {
            CallMoveEvent(direction);   // 아니면 추적
        }
    }

    private void TryShootAtTarget(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget);   // 공격 감지

        if (hit.collider != null) // 명중 시 공격 성공 모션
        {
            PerformAttackAction(direction);
        }
        else    // 실패 시 다시 이동
        {
            CallMoveEvent(direction);
        }
    }

    private void PerformAttackAction(Vector2 direction)
    {
        CallLookEvent(direction);   // 공격 대상 바라보고
        CallMoveEvent(Vector2.zero);    // 이동 멈춤
        IsAttacking = true;
    }
}