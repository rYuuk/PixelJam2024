using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundEffectsVolumeSlider;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExit);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExit);
    }

    private void OnExit()
    {
        gameObject.SetActive(false);
    }
}

