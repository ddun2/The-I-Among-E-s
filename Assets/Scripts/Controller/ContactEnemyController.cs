using System;
using UnityEngine;

public class ContactEnemyController : EnemyController
{    
    [SerializeField] private string targetTag = "Player";
    private bool isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    CollisionSystem collisionSystem;
    private CollisionSystem targetCollisionSystem;
    private IAEMovement targetMovement;

    protected override void Start()
    {
        base.Start();
        collisionSystem = GetComponent<CollisionSystem>();
    }

    protected override void FixedUpdate()
    {        
        base.FixedUpdate();

        if (isCollidingWithTarget)
        {
            ApplyLifeChange();
        }

        Vector2 direction = DirectionToTarget();
        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void ApplyLifeChange()
    {        
        AttackSO attackSO = stats.CurrentStat.attackSO;
        bool isAttackable = targetCollisionSystem.ChangeLife();

        if (isAttackable && attackSO.isOnKnockBack && targetMovement != null)
        {
            targetMovement.ApplyKnockBack(transform, attackSO.knockBackPower, attackSO.knockBackTime);
        }
    }

    private void Rotate(Vector2 direction)  // 몬스터 방향 뒤집기
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;

        if (!receiver.CompareTag(targetTag))
        {
            return;
        }

        targetCollisionSystem = collision.GetComponent<CollisionSystem>();
        if (targetCollisionSystem != null)
        {
            isCollidingWithTarget = true;
        }

        targetMovement = collision.GetComponent<IAEMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
        {
            return;
        }
        isCollidingWithTarget = false;
    }
}