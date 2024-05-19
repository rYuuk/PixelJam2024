using UnityEngine;
using UnityEngine.UI;

public class GameFinishedMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameFinishedMenu;
    [SerializeField] private Button replayButton;
    [SerializeField] private Button creditsButton;

    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private CreditMenu creditMenu;

    private void OnEnable()
    {
        replayButton.onClick.AddListener(OnReplay);
        creditsButton.onClick.AddListener(OnCredits);
        returnToMenuButton.onClick.AddListener(OnReturnToMenu);
    }

    public void Toggle(bool enable)
    {
        Time.timeScale = enable ? 0 : 1;
        gameFinishedMenu.SetActive(enable);
    }

    private async void OnReturnToMenu()
    {
        Time.timeScale = 1;
        Toggle(false);
        await LevelLoader.Instance.ReturnToMenu();
    }

    private async void OnReplay()
    {
        Time.timeScale = 1;
        Toggle(false);
        await LevelLoader.Instance.RestartCurrentLevel();
    }

    private  void OnCredits()
    {
        creditMenu.Toggle();
    }
}
