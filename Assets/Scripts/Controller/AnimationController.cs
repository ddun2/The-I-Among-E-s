using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected IAEController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();    
        controller = GetComponent<IAEController>();
    }
}
