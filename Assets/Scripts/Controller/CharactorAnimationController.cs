using System;
using UnityEngine;

public class CharactorAnimationController : AnimationController
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Ishit = Animator.StringToHash("Ishit");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private readonly float magnituteThreshold = 0.5f;


    protected override void Awake()
    {
        base.Awake();
    }


    private void Start()
    {
        controller.OnAttackEvent += Attackking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(IsWalking, vector.magnitude > magnituteThreshold);
    }

    private void Attackking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(Ishit, true);
    }

    private void InvincibilityEnd()
    {
        animator.SetBool(Ishit,false);
    }
}