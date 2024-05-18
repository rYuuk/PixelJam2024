using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LightiningSpawner swordAttack;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float attackDelay = 0.5f;

    private float health;

    private bool isAttacking;
    private bool canAttack;

    private float lastAttackTime;

    private void Start()
    {
        health = maxHealth;
        playerAnimation.SwordAttackStarted += StartSwordAttack;
        playerAnimation.SwordAttackEnded += EndSwordAttack;
        playerAnimation.DeathAnimationCompleted += DeathAnimationCompleted;
    }

    private void Update()
    {
        if (isAttacking && Time.time - lastAttackTime > attackDelay)
        {
            lastAttackTime = Time.time;
            isAttacking = false;
        }
    }

    private void DeathAnimationCompleted()
    {
        // GameManager.Instance.SetState(GameManager.State.GameOver);
    }

    public void OnAttack()
    {
        if (isAttacking)
        {
            return;
        }

        playerAnimation.PlayAttackAnimation();
        isAttacking = true;
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
        // swordAttack.StopAttack();
    }

    public void ReceiveHealth(float additionalHealth)
    {
        health += additionalHealth;
        HUD.Instance.SetHealth(health / maxHealth);
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        HUD.Instance.SetHealth(health / maxHealth);

        playerAnimation.PlayHurtAnimation();

        if (health < 0)
        {
            playerAnimation.PlayDeathAnimation();
            GameManager.Instance.SetState(GameManager.State.GameOver);
        }
    }
}