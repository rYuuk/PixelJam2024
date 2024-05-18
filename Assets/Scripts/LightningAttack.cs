using System;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 1;

    private Rigidbody2D rb;
    private float damage;
    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("" + other.gameObject.name);
        var enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            animator.SetTrigger("Hit");
            enemy.ReceiveDamage(damage);
        }
    }

    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void SetSpriteOrientation(bool isFlip)
    {
        if (!isFlip)
        {
            var rotation = spriteRenderer.transform.rotation.eulerAngles;
            spriteRenderer.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, -rotation.z);
            spriteRenderer.flipX = !isFlip;
        }
    }
}
