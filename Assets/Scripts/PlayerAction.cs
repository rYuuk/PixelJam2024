using System;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SwordAttack swordAttack;
    [SerializeField] private float maxHealth = 100f;
    private float health;
    private void Start()
    {
        health = maxHealth;
        playerAnimation.SwordAttackStarted += StartSwordAttack;
        playerAnimation.SwordAttackEnded += EndSwordAttack;
        playerAnimation.DeathAnimationCompleted += DeathAnimationCompleted;
    }

    private void DeathAnimationCompleted()
    {
        // GameManager.Instance.SetState(GameManager.State.GameOver);
    }

    public void OnAttack()
    {
        playerAnimation.PlayAttackAnimation();
    }

    public void StartSwordAttack()
    {
        playerController.LockMovement();

        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft(playerData.Attack);
        }
        else
        {
            swordAttack.AttackRight(playerData.Attack);
        }
    }

    public void EndSwordAttack()
    {
        playerController.UnlockMovement();
        swordAttack.StopAttack();
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        HUD.Instance.SetHealth(health / maxHealth);

        if (health < 0)
        {
            playerAnimation.PlayDeathAnimation();
        }
    }
}