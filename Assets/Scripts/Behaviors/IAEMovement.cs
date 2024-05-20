using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEMovement : MonoBehaviour
{
    private IAEController controller;
    private Rigidbody2D movementRb;
    private Vector2 movementDir = Vector2.zero;
    private CharacterStatHandler characterStatHandler;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        controller = GetComponent<IAEController>();
        movementRb = GetComponent<Rigidbody2D>();
        characterStatHandler = GetComponent<CharacterStatHandler>(); 
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDir = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDir);

        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    public void ApplyKnockBack(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;  // 힘이 더해지며 뒤로 밀림
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= characterStatHandler.CurrentStat.speed;

        if (knockbackDuration > 0.0f)
        {
            direction += knockback;
        }

        movementRb.velocity = direction;
    }
}
