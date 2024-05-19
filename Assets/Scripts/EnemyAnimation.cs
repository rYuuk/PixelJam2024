using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    public event Action DefeatedAnimationCompleted;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDefeatAnimation()
    {
        animator.SetTrigger("Defeated");
    }

    public void PlayMoveAnimation(bool isMoving)
    {
        animator.SetBool("IsMoving", isMoving);
    }

    public void PlayCollisionAnimation()
    {
        animator.SetTrigger("Hit");
        PlayMoveAnimation(false);
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void OnDefeatedAnimationComplete()
    {
        DefeatedAnimationCompleted?.Invoke();
    }
}
