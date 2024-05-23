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
    private Color oringColor;

    public event Action OnDamage;
    public event Action OnDeath;
    public event Action OnInvincibillityEnd;

    public int CurrentLife { get; private set; }

    private void Awake()
    {
        oringColor = new Color(1f, 1f, 1f, 1f);
        statHandler = GetComponent<CharacterStatHandler>();        
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

        //OnDamage?.Invoke();
        isAttacked = true;
        SetBlink();
        return true;
    }

    public void CallDeath()
    {        
        OnDeath?.Invoke();        
    }

    private void SetBlink()
    {
        if (isAttacked)
        {
            StartCoroutine("BlinkOnDamaged", gameObject);
            isAttacked = true;
        }
        else
        {
            StopCoroutine("BlinkOnDamaged");
            this.GetComponentInChildren<SpriteRenderer>().color = oringColor;
            isAttacked = false;
        }
    }

    private IEnumerator BlinkOnDamaged(GameObject ojb)
    {
        Color currentColor = oringColor;
        int count = 0;

        gameObject.GetComponentInChildren<SpriteRenderer>().color = currentColor;

        // 전체 루틴이 2번 실행됨
        while(count < 4)
        {
            count++;
            // SpriteRenderer의 알파값에 따라서 줄이고 늘리고 반복
            while(ojb.GetComponentInChildren<SpriteRenderer>().color.a > 0f)
            {
                currentColor.a -= 0.1f;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = currentColor;
            }
            yield return new WaitForSeconds(0.1f);
            while (gameObject.GetComponentInChildren<SpriteRenderer>().color.a < 1f)
            {
                currentColor.a += 0.1f;
                gameObject.GetComponentInChildren<SpriteRenderer>().color = currentColor;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}

