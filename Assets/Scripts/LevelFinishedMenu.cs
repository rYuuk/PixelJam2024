using UnityEngine;
using UnityEngine.UI;

public class LevelFinishedMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishedMenu;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button returnToMenuButton;

    private void OnEnable()
    {
        nextLevelButton.onClick.AddListener(OnNextLevel);
        replayButton.onClick.AddListener(OnReplay);
        returnToMenuButton.onClick.AddListener(OnReturnToMenu);
    }

    public void Toggle(bool enable)
    {
        // Time.timeScale = enable ? 0 : 1;
        levelFinishedMenu.SetActive(enable);
    }

    private async void OnReturnToMenu()
    {
        // Time.timeScale = 1;
        Toggle(false);
        await LevelLoader.Instance.ReturnToMenu();
    }

    private async void OnReplay()
    {
        // Time.timeScale = 1;
        Toggle(false);
        await LevelLoader.Instance.RestartCurrentLevel();
    }

    private async void OnNextLevel()
    {
        // Time.timeScale = 1;
        Toggle(false);
        Loading.Instance.SetActive(true);
        await LevelLoader.Instance.LoadNextLevel();
        Loading.Instance.SetActive(false);
    }
}
