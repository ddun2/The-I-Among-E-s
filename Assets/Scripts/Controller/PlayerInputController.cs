using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : IAEController
{
    private Camera Camera;
    private void Awake()
    {
        Camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 MoveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(MoveInput);
    }

    public void Onlook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = Camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

}
