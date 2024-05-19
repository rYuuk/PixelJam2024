using UnityEngine;

public class BubbleAtttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 1;
    [SerializeField] private float duration = 1;

    private Rigidbody2D rb;
    private float damage;
    private Vector2 direction = Vector2.left;
    private float startTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(DestroySelf), duration);
    }

    private void DestroySelf()
    {
        animator.SetTrigger("Hit");
        // Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetTrigger("Hit");
        if (other.gameObject.CompareTag("Player"))
        {
            var playerAction = other.gameObject.GetComponent<PlayerAction>();
            playerAction.ReceiveDamage(damage);
        }
    }

    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
        CancelInvoke(nameof(DestroySelf));
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}