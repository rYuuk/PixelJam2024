using UnityEngine;

public class Friends : MonoBehaviour
{
    [SerializeField] private GameObject orca;
    [SerializeField] private GameObject turtle;
    [SerializeField] private GameObject mermaid;

    public void Toggle(int level)
    {
        switch (level)
        {
            case 3:
                turtle.SetActive(true);
                break;
            case 4:
                turtle.SetActive(true);
                orca.SetActive(true);
                break;
        }
    }

    public void GameFinish(Vector3 position)
    {
        Debug.Log("pos: " + position.ToString("F2"));
        mermaid.SetActive(true);
        // mermaid.transform.position = position;
    }
}
