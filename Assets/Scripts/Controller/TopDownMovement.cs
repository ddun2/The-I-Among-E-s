using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private IAEController controller;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementdirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<IAEController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        }

    private void Move(Vector2 direction)
    {
        movementdirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementdirection);   
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;
    }
}
