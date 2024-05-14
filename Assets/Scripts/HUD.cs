using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    [SerializeField] private Slider healthBar;

    private void Start()
    {
        Instance = this;
    }

    public void SetHealth(float healthRatio)
    {
        healthBar.value = healthRatio;
    }
}
