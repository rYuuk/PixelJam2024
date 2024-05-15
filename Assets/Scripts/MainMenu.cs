using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        var async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        while (!async.isDone && async.progress < 0.9f)
        {
            await Task.Yield();
        }
        async.allowSceneActivation = true;

        while (!async.isDone)
        {
            await Task.Yield();
        }

        await SceneManager.UnloadSceneAsync(0);

        Loading.Instance.SetActive(false);
    }

    private void OnQuitButton()
    {
        Application.Quit();
    }
}
