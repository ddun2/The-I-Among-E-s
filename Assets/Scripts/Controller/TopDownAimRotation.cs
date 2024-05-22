using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer charactorRenderer;

    private IAEController controller;

    private void Awake()
    {
        controller = GetComponent<IAEController>();
    }

    void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

        charactorRenderer.flipX = MathF.Abs(rotZ) > 90f;

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
