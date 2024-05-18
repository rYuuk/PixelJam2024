using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [SerializeField] private float value;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerAction = other.GetComponent<PlayerAction>();
            if (playerAction != null)
            {
                playerAction.ReceiveHealth(value);
                Destroy(gameObject);
            }
        }
    }

}
