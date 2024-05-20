using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEMovement : MonoBehaviour
{
    private IAEController controller;
    private Rigidbody2D movementRb;
    private Vector2 movementDir = Vector2.zero;
    private CharacterStatHandler characterStatHandler;

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
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= characterStatHandler.CurrentStat.speed;
        movementRb.velocity = direction;
    }
}
