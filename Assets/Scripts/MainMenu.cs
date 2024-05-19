using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private Button exitCreditMenu;

    private void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButton);
        settingsButton.onClick.AddListener(OnSettingsButton);
        quitButton.onClick.AddListener(OnQuitButton);
        creditButton.onClick.AddListener(OnCredit);
        exitCreditMenu.onClick.AddListener(OnExitCreditMenu);
    }

    private void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButton);
        settingsButton.onClick.RemoveListener(OnSettingsButton);
        quitButton.onClick.RemoveListener(OnQuitButton);
        creditButton.onClick.RemoveListener(OnCredit);
        exitCreditMenu.onClick.RemoveListener(OnExitCreditMenu);
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

    private void OnCredit()
    {
        creditMenu.SetActive(true);
    }

    private void OnExitCreditMenu()
    {
        creditMenu.SetActive(false);
    }

}
