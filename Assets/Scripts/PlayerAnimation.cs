using System;
using DG.Tweening;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform character;
    private float originalY; // Store the original Y position
    public float floatStrength = 1f;
    public float speed = 2f;

    public event Action SwordAttackStarted;
    public event Action SwordAttackEnded;
    public event Action DeathAnimationCompleted;

    private void Awake()
    {
        originalY = character.localPosition.y;
    }

    void Update()
    {
        Vector3 newPosition = character.localPosition;
        newPosition.y = originalY + (Mathf.Sin(Time.time * speed) * floatStrength);
        character.localPosition = newPosition;
    }

    public void PlayMoveAnimation(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("swordAttack");
    }

    public void PlayHurtAnimation()
    {
        animator.SetTrigger("isHurt");
    }

    public void SwordAttackStart()
    {
        SwordAttackStarted?.Invoke();
    }

    public void SwordAttackEnd()
    {
        SwordAttackEnded?.Invoke();
    }

    public void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    public void DeathAnimationComplete()
    {
        DeathAnimationCompleted?.Invoke();
    }
}