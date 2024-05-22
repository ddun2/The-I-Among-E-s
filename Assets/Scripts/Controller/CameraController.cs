using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector2 minPos = new Vector2(-3f, -6f);
    private Vector2 maxPos = new Vector2(2f, 15f);
    private float smooth = 0.2f;

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        // 카메라 이동 경계 설정
        targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth);
    }
}
