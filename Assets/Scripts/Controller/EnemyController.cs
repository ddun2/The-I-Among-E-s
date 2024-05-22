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

    protected virtual float DistanceToTarget()  // ���Ϳ� �÷��̾��� �Ÿ�
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget()   // ���Ͱ� �÷��̾ �ٶ󺸴� ����
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}
