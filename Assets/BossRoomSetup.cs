using DG.Tweening;
using Unity.Collections;
using UnityEngine;

public class BossRoomSetup : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private TurtleMovement turtleMovement;
    [SerializeField] private GameObject cameraPos;
    [SerializeField] private GameObject closeDoor;

    [SerializeField] private GameObject showBossHealthBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject;
            var cam = player.GetComponentInChildren<Camera>();
            closeDoor.SetActive(true);

            if (cam != null)
            {
                cam.transform.SetParent(cameraPos.transform);
                cam.transform.DOLocalMove(Vector3.zero, 2).OnComplete(() =>
                {
                    showBossHealthBar.SetActive(true);
                    turtleMovement.SetMove(true);
                });
            }
        }
    }
}
