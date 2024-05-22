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
            Debug.Log("발사체 파괴(몰라)");
        }

        rigidbody.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 벽과 충돌했을 때
        if(IsLayerMatched(levelLayer.value, collision.gameObject.layer))
        {
            Debug.Log(levelLayer);
            Debug.Log(collision.gameObject);
            // 충돌 지점보다 앞에서 발사체 파괴
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestory);
            Debug.Log("발사체 파괴(벽)");
        }
        // 타겟과 충돌했을 때
        else if(IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            // 넉백
            ApplyKnockBack(collision);

            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
            Debug.Log("발사체 파괴(플레이어)");
        }
    }

    // 레이어 확인 메소드
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    // 넉백 적용하는 메소드
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
            //TODO : 이펙트 추가하기
        }
        
        gameObject.SetActive(false);
    }
}
