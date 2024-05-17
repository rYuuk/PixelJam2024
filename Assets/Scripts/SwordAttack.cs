using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] private Collider2D swordCollider;
    private Vector2 rightAttackOffset;

    private float damage;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight(float damage)
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        this.damage = damage;
    }

    public void AttackLeft(float damage)
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        this.damage = damage;
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponentInParent<Enemy>();

            // Deal damage to the enemy
            if (enemy != null)
            {
                enemy.ReceiveDamage(damage);
            }
        }
    }
}
