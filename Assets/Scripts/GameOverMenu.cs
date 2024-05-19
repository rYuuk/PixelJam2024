using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private const string CURRENT_LEVEL = nameof(CURRENT_LEVEL);

    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private Button retry;
    [SerializeField] private Button returnToMenuButton;

    private void OnEnable()
    {
        retry.onClick.AddListener(OnRetry);
        returnToMenuButton.onClick.AddListener(OnReturnToMenu);
    }

    public void Toggle(bool enable)
    {
        Time.timeScale = enable ? 0 : 1;
        gameOverMenu.SetActive(enable);
    }

    private async void OnRetry()
    {
        Time.timeScale = 1;
        Loading.Instance.SetActive(true);
        await LevelLoader.Instance.RestartCurrentLevel();
    }

    private async void OnReturnToMenu()
    {
        Time.timeScale = 1;
        await LevelLoader.Instance.ReturnToMenu();
    }

}
