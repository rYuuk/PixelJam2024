using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundEffectsVolumeSlider;
    [SerializeField] private Button exitButton;
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private GameObject settings;

    private void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        audioMixer.SetFloat("masterVol", Mathf.Log10(masterVolumeSlider.value) * 20);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        audioMixer.SetFloat("musicVol", Mathf.Log10(masterVolumeSlider.value) * 20);
        soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.75f);
        audioMixer.SetFloat("sfxVol", Mathf.Log10(masterVolumeSlider.value) * 20);

    }

    private void OnEnable()
    {
        exitButton.onClick.AddListener(OnExit);
        masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        musicVolumeSlider.onValueChanged.AddListener(OnMusicChanged);
        soundEffectsVolumeSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    private void OnDisable()
    {
        exitButton.onClick.RemoveListener(OnExit);
        masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
        musicVolumeSlider.onValueChanged.RemoveListener(OnMusicChanged);
        soundEffectsVolumeSlider.onValueChanged.RemoveListener(OnSFXChanged);
    }

    private void OnExit()
    {
        settings.SetActive(false);
    }
    private void OnSFXChanged(float value)
    {
        audioMixer.SetFloat("sfxVol", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }

    private void OnMusicChanged(float value)
    {
        audioMixer.SetFloat("musicVol", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void OnMasterVolumeChanged(float value)
    {
        audioMixer.SetFloat("masterVol", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);

    }

}

