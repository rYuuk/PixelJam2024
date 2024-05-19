using UnityEngine;

public class Friends : MonoBehaviour
{
    [SerializeField] private GameObject orca;
    [SerializeField] private GameObject turtle;

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
}
