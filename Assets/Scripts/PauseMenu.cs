using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    private bool isEnable = false;

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(OnResume);
        settingsButton.onClick.AddListener(OnSettings);
        quitButton.onClick.AddListener(OnQuit);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    private void OnSettings()
    {
    }

    private void OnResume()
    {
        Toggle(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Toggle(isEnable ? !enabled : enabled);
        }
    }

    private void Toggle(bool enable)
    {
        isEnable = enable;
        Time.timeScale = enable ? 0 : 1;
        pauseScreen.SetActive(enable);
    }
}
