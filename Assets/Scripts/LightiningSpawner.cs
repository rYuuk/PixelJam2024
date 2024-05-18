using Unity.Mathematics;
using UnityEngine;

public class LightiningSpawner : MonoBehaviour
{
    [SerializeField] private LightningAttack lightningAttackPrefab;
    private Vector2 rightAttackOffset;

    private void Start()
    {
        rightAttackOffset = transform.localPosition;
    }

    public void SpawnRight(float damage)
    {
        Debug.Log("Spawn right");

        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);

        Attack(damage, true);
    }

    public void SpawnLeft(float damage)
    {
        transform.localPosition = rightAttackOffset;
        Debug.Log("Spawn left");
        Attack(damage, false);
    }

    private void Attack(float damage, bool flip)
    {
        var lightningAttack = Instantiate(lightningAttackPrefab, transform.position, quaternion.identity);
        lightningAttack.SetDamage(damage);
        var direction = (transform.position - transform.parent.position).normalized;
        lightningAttack.SetDirection(new Vector3(direction.x, 0f, 0f).normalized);
        lightningAttack.SetSpriteOrientation(flip);
    }
}
