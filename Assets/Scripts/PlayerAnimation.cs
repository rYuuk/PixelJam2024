using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public event Action SwordAttackStarted;
    public event Action SwordAttackEnded;

    public void PlayMoveAnimation(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttackStart()
    {
        SwordAttackStarted?.Invoke();
    }

    public void SwordAttackEnd()
    {
        SwordAttackEnded?.Invoke();
    }
}