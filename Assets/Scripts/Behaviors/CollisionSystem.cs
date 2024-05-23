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
        // �������¶�� life ���� ����
        if (timeSinceLastOnDamage < lifeChangeDelay)
        {
            return false;
        }

        // ���� ���°� �ƴҶ�
        // ���� ���� �ð� 0���� �ʱ�ȭ
        timeSinceLastOnDamage = 0;

        // ���� ������ 1 ���� ��Ű�� ������ 0�϶� ��� ����
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

