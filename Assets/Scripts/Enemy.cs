using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation enemyAnimation;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float maxHealth = 10;
    [SerializeField] private float damage = 5;
    [SerializeField] private bool isBoss;
    [SerializeField] private GameObject healthDrop;
    [SerializeField, Range(0, 100)] private float healthDropChance;

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

            if (isBoss)
            {
                GameManager.Instance.LevelFinished();
            }
        }
    }

    public void Kill()
    {
        var randomChance = Random.Range(0f, 1f);
        if (healthDrop != null && randomChance < healthDropChance / 100)
        {
            Instantiate(healthDrop, transform.position, Quaternion.identity);
        }

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
