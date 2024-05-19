using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minX;

    private bool isFollowing = true;

    private void Update()
    {
        if (!isFollowing)
        {
            return;
        }

        var pos = player.position;
        var x = Mathf.Max(pos.x, 0);
        transform.position = new Vector3(x, 0, -10);
    }

    public void ToggleFollow(bool follow)
    {
        isFollowing = follow;
    }
}
