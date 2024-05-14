using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    public event Action DefeatedAnimationCompleted;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDefeatAnimation()
    {
        animator.SetTrigger("Defeated");
    }

    public void OnDefeatedAnimationComplete()
    {
        DefeatedAnimationCompleted?.Invoke();
    }
}
