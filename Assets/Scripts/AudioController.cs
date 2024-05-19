using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [SerializeField] private AudioClip gameComplete;
    [SerializeField] private AudioClip bossMusic;
    [SerializeField] private AudioClip levelMusic;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    public async void PlayGameCompleteMusic()
    {
        await audioSource.StartFade(1, 0);
        audioSource.Stop();
        audioSource.clip = gameComplete;
        audioSource.Play();
        audioSource.volume = 1;
    }

    public async void PlayBossMusic()
    {
        await audioSource.StartFade(1, 0);
        audioSource.Stop();
        audioSource.clip = bossMusic;
        audioSource.Play();
        audioSource.volume = 1;
    }

    public async void PlayLevelMusic()
    {
        await audioSource.StartFade(0.2f, 0);
        
        audioSource.Stop();
        audioSource.clip = levelMusic;
        audioSource.Play();
        audioSource.volume = 1;
    }
}
