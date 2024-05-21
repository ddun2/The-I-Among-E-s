using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEAimRotaion : MonoBehaviour
{
    
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

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
        RotateAim(direction);
    }

    private void RotateAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
