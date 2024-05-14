
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform enemyCharacter;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private bool canMove = true;
    private Transform nextDestination;

    private void Start()
    {
        nextDestination = end;
    }
    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        MoveTowardsCheckpoint();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(end.position, 0.02f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(start.position, 0.02f);

    }

    public void SetMovement(bool enable)
        => canMove = enable;

    private void MoveTowardsCheckpoint()
    {
        var directionVector = (nextDestination.position - enemyCharacter.position).normalized;

        enemyCharacter.Translate(directionVector * (movementSpeed * Time.deltaTime), Space.World);

        // Check if the enemy has reached the current checkpoint
        if (Vector3.Distance(enemyCharacter.position, nextDestination.position) < 0.1f)
        {
            if (nextDestination == start)
            {
                nextDestination = end;
                spriteRenderer.flipX = false;
            }
            else
            {
                nextDestination = start;
                spriteRenderer.flipX = true;
            }
        }
    }
}