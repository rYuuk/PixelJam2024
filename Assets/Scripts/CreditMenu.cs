using UnityEngine;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button brianneLinkedInButton;
    [SerializeField] private Button anaLinkedInButton;
    [SerializeField] private Button anaItchioInButton;
    [SerializeField] private Button robinLinkedInButton;
    [SerializeField] private bool goBackToMenuOnExit;

    private void Start()
    {
        brianneLinkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/brianne-do/"));
        anaLinkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/ana-louise-trinidad/"));
        anaItchioInButton.onClick.AddListener(() => Application.OpenURL("https://ana3nity.itch.io/"));
        robinLinkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/robinsharma5/"));
    }

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExit);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExit);
    }

    public void Toggle()
    {
        creditMenu.SetActive(true);
    }

    private async void OnExit()
    {
        creditMenu.SetActive(false);
        if (goBackToMenuOnExit)
        {

            Time.timeScale = 1;
            await LevelLoader.Instance.ReturnToMenu();
        }
    }
}
