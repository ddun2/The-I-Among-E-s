using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    [SerializeField] private float lifeChangeDelay;
    private bool isAttacked = false;

    private CharacterStatHandler statHandler;
    private float timeSinceLastOnDamage = float.MaxValue;


    public event Action OnDamage;
    public event Action OnDeath;
    public event Action OnInvincibillityEnd;

    public int CurrentLife { get; private set; }

    private Animator animator;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();      
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CurrentLife = statHandler.CurrentStat.life;
    }

    private void Update()
    {
        if (isAttacked && timeSinceLastOnDamage < lifeChangeDelay)
        {            
            timeSinceLastOnDamage += Time.deltaTime;
            if (timeSinceLastOnDamage >= lifeChangeDelay)
            {
                OnInvincibillityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    public bool ChangeLife()
    {
        Debug.Log("CL");
        // 무적상태라면 life 변경 안함
        if (timeSinceLastOnDamage < lifeChangeDelay)
        {
            return false;
        }

        // 무적 상태가 아닐때
        // 무적 판정 시간 0으로 초기화
        timeSinceLastOnDamage = 0;

        // 현재 생명을 1 감소 시키고 생명이 0일때 사망 판정
        CurrentLife -= 1;

        if(this.tag == "Player")
            HealthManager.health--;
        if (HealthManager.health <= 0)
        {
            GameManager.isGameOver = true;
        }

        if (CurrentLife <= 0)
        {
            CallDeath();
            return true;
        }

        OnDamage?.Invoke();
        isAttacked = true;
        animator.SetTrigger("ChangeColler");

        return true;
    }

    public void CallDeath()
    {        
        OnDeath?.Invoke();        
    }
}

