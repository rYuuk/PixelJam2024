using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject settings;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButton);
        settingsButton.onClick.AddListener(OnSettingsButton);
        quitButton.onClick.AddListener(OnQuitButton);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButton);
        settingsButton.onClick.RemoveListener(OnSettingsButton);
        quitButton.onClick.RemoveListener(OnQuitButton);
    }

    private void OnSettingsButton()
    {
        settings.gameObject.SetActive(true);
    }

    private async void OnStartButton()
    {
        Loading.Instance.SetActive(true);
        await LevelLoader.Instance.StartGame();
    }

    private void OnQuitButton()
    {
        Application.Quit();
    }
}
