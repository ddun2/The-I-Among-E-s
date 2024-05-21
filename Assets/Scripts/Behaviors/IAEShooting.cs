using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class IAEShooting : MonoBehaviour
{
    private IAEController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    private void Awake()
    {
        controller = GetComponent<IAEController>();
    }

    void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot(AttackSO attackSO)
    {
        float projectilesAngleSpace = attackSO.multipleShotAngle;
        int numberOfProjectilesPerShot = attackSO.numberOfProjectilePerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * attackSO.multipleShotAngle;
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-attackSO.spread, attackSO.spread);
            angle += randomSpread;
            CreateProjectile(attackSO, angle);
        }
    }

    private void CreateProjectile(AttackSO attackSO, float angle)
    {
        // TODO :: ProjectileController Ãß°¡
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool(attackSO.projectileNameTag);
        obj.transform.position = projectileSpawnPosition.position;
        // ProjectileController attackController = obj.GetComponent<ProjectileController>();
        // attackController.InitializeAttack(RotateVector2(aimDirection, angle), attackSO);
    }

    private object RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
