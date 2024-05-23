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

        // ��ü ��ƾ�� 2�� �����
        while(count < 4)
        {
            count++;
            // SpriteRenderer�� ���İ��� ���� ���̰� �ø��� �ݺ�
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

