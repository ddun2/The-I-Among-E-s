using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyCharacter : MonoBehaviour
{
    // 1. 충돌 시 소멸
    // 2. 맵 밖으로 벗어나면 소멸 (몬스터)
    private Rigidbody2D rigidbody;
    private CollisionSystem collisionSystem;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collisionSystem = GetComponent<CollisionSystem>();
        collisionSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        // 이동을 멈춘다
        rigidbody.velocity = Vector2.zero;

        // TODO :: 사망 애니메이션 추가하기(색 변화 등)
        // 플레이어 사망 시 => 천천히 빨간색으로 변경
        // 적 사망 시 => 페이드아웃처리?
        
        // 플레이어의 사망 처리
        if(rigidbody.tag == "Player")
        {
            // 빨간색으로 변경
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            Color color = Color.red;
            renderer.color = color;
            
            // 조작을 멈춘다
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = false;
            Destroy(gameObject, 5f);
        }

        // 1초 뒤에 소멸
        // TODO:: SetActive(false)로 변경, 오브젝트 풀 이용하기 위함
        else
        {
            gameObject.SetActive(false);
        }
    }

    // TODO :: 몬스터가 화면 밖으로 벗어나게 할지 벽에 충돌하게 할지 정하기
    // 몬스터도 벽에 충돌
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
