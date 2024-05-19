using DG.Tweening;
using UnityEngine;

public class BossRoomSetup : MonoBehaviour
{
    [SerializeField] private GameObject cameraPos;
    [SerializeField] private GameObject closeDoor;

    [SerializeField] private GameObject showBossHealthBar;
    [SerializeField] private GameObject enemyBehaviourGameObject;

    private IEnemyBehaviour enemyBehaviour;

    private bool firstTime;

    private void Awake()
    {
        enemyBehaviour = enemyBehaviourGameObject.GetComponent<IEnemyBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!firstTime && other.CompareTag("Player"))
        {
            firstTime = true;
            var player = other.gameObject;
            var cam = Camera.main.GetComponent<CameraFollow>();
            cam.ToggleFollow(false);
            closeDoor.SetActive(true);

            AudioController.Instance.PlayBossMusic();

            if (cam != null)
            {
                cam.transform.DOMove(cameraPos.transform.position, 2).OnComplete(() =>
                {
                    showBossHealthBar.SetActive(true);
                    enemyBehaviour.StartAttack();
                });
            }
        }
    }
}
