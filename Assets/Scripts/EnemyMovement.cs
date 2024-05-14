
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform enemyCharacter;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float playerDetectionRadius = 0.3f;

    private Transform player;
    private Transform nextDestination;

    private bool isDetecting = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextDestination = end;
    }
    private void Update()
    {
        if (isDetecting)
        {
            var distanceToPlayer = Vector3.Distance(enemyCharacter.position, player.position);

            if (distanceToPlayer <= playerDetectionRadius)
            {
                nextDestination = player;
                isDetecting = false;
            }
        }

        MoveTowardsTransform();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(end.position, 0.02f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(start.position, 0.02f);

    }

    private void MoveTowardsTransform()
    {
        var directionVector = (nextDestination.position - enemyCharacter.position).normalized;

        enemyCharacter.Translate(directionVector * (movementSpeed * Time.deltaTime), Space.World);

        // Compute the cross product with reference object's forward vector
        var cross = Vector3.Cross(directionVector, enemyCharacter.forward);

        // Check the sign of the y-component
        if (cross.y > 0)
        {
            // Target is to the right
            spriteRenderer.flipX = false;
        }
        else
        {
            // Target is to the left
            spriteRenderer.flipX = true;
        }

        // Check if the enemy has reached the current checkpoint
        if (nextDestination != player && Vector3.Distance(enemyCharacter.position, nextDestination.position) < 0.1f)
        {
            if (nextDestination == start)
            {
                nextDestination = end;
            }
            else
            {
                nextDestination = start;
            }
        }
    }
}