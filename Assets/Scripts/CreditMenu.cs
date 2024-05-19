using UnityEngine;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExit);
    }

    public void Toggle()
    {
        Time.timeScale = 0;
        creditMenu.SetActive(true);
    }

    private async void OnExit()
    {
        Time.timeScale = 1;
        creditMenu.SetActive(false);
        await LevelLoader.Instance.ReturnToMenu();
    }
}
