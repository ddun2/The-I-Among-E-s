using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelLayer;

    private AttackSO attackData;
    private Vector2 direction;
    private float currentDuration;
    private bool isReady;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    public bool fxOnDestory = true;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (!isReady)
        {
            return;
        }
        currentDuration += Time.deltaTime;

        if (currentDuration > attackData.duration)
        {
            DestroyProjectile(transform.position, false);
            Debug.Log("�߻�ü �ı�(����)");
        }

        rigidbody.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �浹���� ��
        if(IsLayerMatched(levelLayer.value, collision.gameObject.layer))
        {
            Debug.Log(levelLayer);
            Debug.Log(collision.gameObject);
            // �浹 �������� �տ��� �߻�ü �ı�
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestory);
            Debug.Log("�߻�ü �ı�(��)");
        }
        // Ÿ�ٰ� �浹���� ��
        else if(IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            // �˹�
            ApplyKnockBack(collision);

            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
            Debug.Log("�߻�ü �ı�(�÷��̾�)");
        }
    }

    // ���̾� Ȯ�� �޼ҵ�
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    // �˹� �����ϴ� �޼ҵ�
    private void ApplyKnockBack(Collider2D collider)
    {
        IAEMovement movement = collider.GetComponent<IAEMovement>();
        if (movement != null)
        {
            movement.ApplyKnockBack(transform, attackData.knockBackPower, attackData.knockBackTime);
        }
    }

    public void OnAttack(Vector2 direction, AttackSO attackData)
    {
        this.attackData = attackData;
        this.direction = direction;

        currentDuration = 0;

        transform.right = this.direction;
        isReady = true;
    }
    
    private void DestroyProjectile(Vector3 position,bool createFx)
    {
        if(createFx)
        {
            //TODO : ����Ʈ �߰��ϱ�
        }
        
        gameObject.SetActive(false);
    }
}
