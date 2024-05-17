using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private EnemyAnimation enemyAnimation;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float minAngle = -45f; // Minimum angle for random direction
    [SerializeField] private float maxAngle = 45f; // Maximum angle for random direction
    [SerializeField] private float attackMoveDelayTime = 2f;
    [SerializeField] private int turtleHitCountBeforeStunned = 3;
    [SerializeField] private Enemy enemy;

    private Vector2 currentDirection;
    // private Rigidbody2D rb;

    private float startTime;
    private bool canMove;
    private bool waitForStun;

    private int turtleHitCount = 0;

    private void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
        // var player = GameObject.FindGameObjectWithTag("Player");
        // // Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Update()
    {
        if (waitForStun && Time.time - startTime > attackMoveDelayTime)
        {
            startTime = Time.time;
            canMove = true;
            waitForStun = false;
            turtleHitCount = 0;
            enemyAnimation.PlayMoveAnimation(true);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)currentDirection);
    }

    public void SetMove(bool move)
    {
        canMove = move;
        if (move)
        {
            enemyAnimation.PlayMoveAnimation(true);
        }
    }

    private void Move()
    {
        // Move the enemy in the current direction
        // rb.velocity = currentDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + currentDirection * moveSpeed * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionNormal = collision.contacts[0].normal;
        var reflectedDirection = Vector2.Reflect(currentDirection, collisionNormal);
        currentDirection = reflectedDirection.normalized;
        turtleHitCount++;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<PlayerAction>(out var player))
            {
                player.ReceiveDamage(enemy.Damage);
            }
        }
        else
        {
            if (turtleHitCount > turtleHitCountBeforeStunned)
            {
                waitForStun = true;
                enemyAnimation.PlayCollisionAnimation();
                startTime = Time.time;
                canMove = false;

            }
        }
    }

    private void SetRandomDirection()
    {
        // Generate a random angle within the specified range
        float randomAngle = Random.Range(minAngle, maxAngle);
        // Convert angle to a direction vector
        currentDirection = Vector2.one * -0.5f;
    }
}
