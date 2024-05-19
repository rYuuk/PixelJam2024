using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 1;
    [SerializeField] private float duration = 1;
    [SerializeField] private AudioClip onImpactAudio;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private float damage;
    private Vector2 direction;
    private float startTime;

    private bool stopWait;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(DestroySelf), duration);
    }

    private void DestroySelf()
    {
        stopWait = true;
        // animator.SetTrigger("Hit");
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * direction);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IgnoreAttack>())
        {
            Hit();
            return;
        }

        var enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            Hit();
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
        if (isFlip)
        {
            var rotation = spriteRenderer.transform.rotation.eulerAngles;
            spriteRenderer.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, -rotation.z);
            spriteRenderer.flipX = true;
        }
    }

    private async void Hit()
    {
        animator.SetTrigger("Hit");
        audioSource.Stop();
        audioSource.PlayOneShot(onImpactAudio, 0.4f);
        CancelInvoke(nameof(DestroySelf));
        // Destroy(gameObject);
    }
}
