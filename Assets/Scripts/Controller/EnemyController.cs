using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IAEController
{
    protected Transform ClosestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        ClosestTarget = GameManager.Instance.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual float DistanceToTarget()  // 몬스터와 플레이어의 거리
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget()   // 몬스터가 플레이어를 바라보는 방향
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}
