using Unity.Mathematics;
using UnityEngine;

public class LightiningSpawner : MonoBehaviour
{
    [SerializeField] private LightningAttack lightningAttackPrefab;
    private Vector2 rightAttackOffset;

    private float damage;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void AttackRight(float damage)
    {
        transform.localPosition = rightAttackOffset;
        this.damage = damage;

        var lightningAttack = Instantiate(lightningAttackPrefab, transform.position, quaternion.identity);
        lightningAttack.SetDamage(damage);
        var direction = (transform.position - transform.parent.position).normalized;
        lightningAttack.SetDirection(new Vector3(direction.x, 0f, 0f).normalized);
        lightningAttack.SetSpriteOrientation(true);
    }

    public void AttackLeft(float damage)
    {
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        this.damage = damage;

        var lightningAttack = Instantiate(lightningAttackPrefab, transform.position, quaternion.identity);
        lightningAttack.SetDamage(damage);

        var direction = (transform.position - transform.parent.position).normalized;
        lightningAttack.SetDirection(new Vector3(direction.x, 0f, 0f).normalized);
        lightningAttack.SetSpriteOrientation(false);

    }
}
