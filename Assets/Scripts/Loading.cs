using UnityEngine;

public class Loading : MonoBehaviour
{
    public static Loading Instance { get; private set; }
    [SerializeField] private GameObject canvas;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetActive(bool active)
    {
        canvas.SetActive(active);
    }
}
