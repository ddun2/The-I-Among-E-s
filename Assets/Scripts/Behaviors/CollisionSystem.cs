using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    private bool isAttacked = false;

    public event Action OnDeath;
    public event Action OnInvincibillityEnd;

    private void Update()
    {
        
    }

    public bool IsAttacked()
    {
        CallDeath();
        return true;
    }

    public void CallDeath()
    {
        OnDeath?.Invoke();
    }



    // ------- ContackEnemyContoller.cs

    //// 공격 실행
    //private void ApplyAttack()
    //{
    //    AttackSO attackSO = stats.CurrentStat.AttackSO;
    //    // 공격이 가능한지 판별 및 공격 적용
    //    bool isAttackable = true;

    //    if (isAttackable && attackSO.isOnKnockBack && collidingMovement != null)
    //    {
    //        collidingMovement.ApplyKnockBack(transform, attackSO.knockBackPower, attackSO.knockBackTime);
    //    }
    //}

}

