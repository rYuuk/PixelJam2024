using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation enemyAnimation;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private float damage = 5;

    public float Damage => damage;
    private float health;

    private void Start()
    {
        health = maxHealth;
        enemyAnimation.DefeatedAnimationCompleted += Kill;
    }

    public void ReceiveDamage(float amount)
    {
        health -= amount;
        healthBar.value = health / maxHealth;

        if (health <= 0)
        {
            enemyAnimation.PlayDefeatAnimation();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerAction>(out var player))
            {
                player.ReceiveDamage(damage);
            }
        }
    }
}
