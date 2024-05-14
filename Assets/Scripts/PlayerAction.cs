using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SwordAttack swordAttack;

    private void Start()
    {
        playerAnimation.SwordAttackStarted += StartSwordAttack;
        playerAnimation.SwordAttackEnded += EndSwordAttack;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponentInParent<Enemy>())
            {
                Debug.Log("Oi");
            }
        }
    }
}