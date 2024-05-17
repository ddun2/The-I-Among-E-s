using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacter : MonoBehaviour
{
    // 1. �浹 �� �Ҹ�
    // 2. �� ������ ����� �Ҹ� (����)
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDeath()
    {
        // �̵��� �����
        rigidbody.velocity = Vector2.zero;

        // TODO :: ��� �ִϸ��̼� �߰��ϱ�(�� ��ȭ ��)

        // 1�� �ڿ� �Ҹ�
        Destroy(gameObject, 1f);
    }

    // TODO :: ���Ͱ� ȭ�� ������ ����� ���� ���� �浹�ϰ� ���� ���ϱ�
    // ȭ�� ������ ����� �Ҹ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
