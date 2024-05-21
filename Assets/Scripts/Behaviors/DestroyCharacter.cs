using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacter : MonoBehaviour
{
    // 1. 충돌 시 소멸
    // 2. 맵 밖으로 벗어나면 소멸 (몬스터)
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDeath()
    {
        // 이동을 멈춘다
        rigidbody.velocity = Vector2.zero;

        // TODO :: 사망 애니메이션 추가하기(색 변화 등)

        // 1초 뒤에 소멸
        // TODO:: SetActive(false)로 변경, 오브젝트 풀 이용하기 위함
        Destroy(gameObject, 1f);
    }

    // TODO :: 몬스터가 화면 밖으로 벗어나게 할지 벽에 충돌하게 할지 정하기
    // 몬스터도 벽에 충돌
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
