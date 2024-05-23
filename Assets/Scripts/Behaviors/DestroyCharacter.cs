using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyCharacter : MonoBehaviour
{
    // 1. �浹 �� �Ҹ�
    // 2. �� ������ ����� �Ҹ� (����)
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
        // �̵��� �����
        rigidbody.velocity = Vector2.zero;

        // TODO :: ��� �ִϸ��̼� �߰��ϱ�(�� ��ȭ ��)
        // �÷��̾� ��� �� => õõ�� ���������� ����
        // �� ��� �� => ���̵�ƿ�ó��?
        
        // �÷��̾��� ��� ó��
        if(gameObject.tag == "Player")
        {
            // ���������� ����
            SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
            Color color = Color.red;
            renderer.color = color;
            
            // ������ �����
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = false;

            Destroy(gameObject, 2f);
            
        }

        // 1�� �ڿ� �Ҹ�
        // TODO:: SetActive(false)�� ����, ������Ʈ Ǯ �̿��ϱ� ����
        else
        {
            MonsterPool obj = GameManager.Instance.monsterPool;
            obj.EnemyDeath();
            GameManager.Instance.GetScore(gameObject);
            gameObject.SetActive(false);
        }
    }    
}
