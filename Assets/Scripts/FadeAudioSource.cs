using System.Threading.Tasks;
using UnityEngine;
public static class FadeAudioSource
{
    public static async Task StartFade(this AudioSource audioSource, float duration, float targetVolume)
    {
        var currentTime = 0f;
        var start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            await Task.Yield();
        }

        await Task.Yield();
    }
}