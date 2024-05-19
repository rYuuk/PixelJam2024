using UnityEngine;

public class OrcaAttackPattern : MonoBehaviour, IEnemyBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private EnemyAnimation enemyAnimation;
    [SerializeField] private BubbleAtttack bubblesPrefab;
    [SerializeField] private Transform mouth;
    [SerializeField] private float attackDelay = 2f;
    [SerializeField] private float damage = 20;

    [SerializeField] private float minAngle = -45;
    [SerializeField] private float maxAngle = 45;
    [SerializeField] private float angleSteps = 5;
    private float angle;

    private bool canAttack = true;
    private bool waitForAttack = true;
    private float startTime = 0;

    private void Start()
    {
        angle = minAngle;
    }

    private void Update()
    {
        if (waitForAttack)
        {
            return;
        }

        if (canAttack)
        {
            startTime = Time.time;
            canAttack = false;

            Attack();
        }
        else
        {
            if (Time.time - startTime > attackDelay)
            {
                canAttack = true;
            }
        }
    }

    public void StartAttack()
    {
        waitForAttack = false;
    }

    private void Attack()
    {
        enemyAnimation.PlayAttackAnimation();
        var bubble = Instantiate(bubblesPrefab, mouth.position, Quaternion.identity);
        bubble.SetDamage(damage);

        var direction = RotateVectorInXYPlane(-mouth.right, angle);

        bubble.SetDirection(direction);
        angle += angleSteps;
        if (angle > maxAngle)
        {
            angle = minAngle;
        }
    }

    private Vector3 RotateVectorInXYPlane(Vector3 vector, float angle)
    {
        // Convert angle to radians
        float radAngle = angle * Mathf.Deg2Rad;

        // Calculate the cosine and sine of the angle
        float cos = Mathf.Cos(radAngle);
        float sin = Mathf.Sin(radAngle);

        // Rotate the vector in the XY plane
        float newX = vector.x * cos - vector.y * sin;
        float newY = vector.x * sin + vector.y * cos;

        return new Vector3(newX, newY, vector.z); // Keep the original z component
    }

}
