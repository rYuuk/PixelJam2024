using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    private const string CURRENT_LEVEL = nameof(CURRENT_LEVEL);

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public async Task StartGame()
    {
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
    }

    public async Task Continue()
    {
        var level = PlayerPrefs.GetInt(CURRENT_LEVEL, 2);
        await LoadSceneAsync(level);
    }

    public async Task RestartCurrentLevel()
    {
        var level = PlayerPrefs.GetInt(CURRENT_LEVEL, 2);
        // await SceneManager.UnloadSceneAsync(level);
        await SceneManager.LoadSceneAsync(1);
    }

    public async Task ReturnToMenu()
    {
        Loading.Instance.SetActive(true);
        await SceneManager.LoadSceneAsync(0);
        Loading.Instance.SetActive(false);
    }

    public async Task ReturnToMenuAndShowCredits()
    {
        await SceneManager.LoadSceneAsync(0);
    }

    public async Task LoadSceneAsync(int level)
    {
        if (SceneManager.GetSceneByBuildIndex(level).IsValid())
        {
            return;
        }
        await SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
    }

    public bool IsLastLevel()
    {
        var level = PlayerPrefs.GetInt(CURRENT_LEVEL, 2);
        if (level == 4)
        {
            return true;
        }

        return false;
    }

    public async Task LoadNextLevel()
    {
        var level = PlayerPrefs.GetInt(CURRENT_LEVEL, 2);
        await SceneManager.UnloadSceneAsync(level);
        await LoadSceneAsync(level + 1);
        PlayerPrefs.SetInt(CURRENT_LEVEL, level + 1);
    }

    public int GetLevel() => PlayerPrefs.GetInt(CURRENT_LEVEL, 2);

    public void ResetLevel()
    {
        PlayerPrefs.SetInt(CURRENT_LEVEL, 2);
    }
}