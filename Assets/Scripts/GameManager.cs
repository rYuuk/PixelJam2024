using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string CURRET_LEVEL = nameof(CURRET_LEVEL);

    public enum State
    {
        None,
        Running,
        Pause,
        Finished,
        GameOver
    }

    public static GameManager Instance { get; private set; }

    private State currentState = State.None;

    private async void Awake()
    {
        Instance = this;
        var level = PlayerPrefs.GetInt(CURRET_LEVEL, 2);
        await SwitchLevel(level);
        Loading.Instance.SetActive(false);

        currentState = State.Running;
    }

    public void SetState(State state)
    {
        switch (state)
        {

        }
    }

    public async Task SwitchLevel(int level)
    {
        await SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
    }
}