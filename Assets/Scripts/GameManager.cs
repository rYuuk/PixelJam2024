using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        None,
        Running,
        Pause,
        LevelFinished,
        GameFinished,
        GameOver
    }

    public static GameManager Instance { get; private set; }

    private State currentState = State.None;
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private PauseMenu pauseMenu;

    private async void Awake()
    {
        Instance = this;
        // await LevelLoader.Instance.Continue();
        // Loading.Instance.SetActive(false);

        currentState = State.Running;
    }

    private void Update()
    {
        if (currentState == State.Running && Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.Toggle();
        }
    }

    public void SetState(State state)
    {
        currentState = state;
        switch (currentState)
        {
            case State.GameOver:
                gameOverMenu.Toggle(true);
                break;

        }
    }

    public async void LevelFinished()
    {
        if (LevelLoader.Instance.IsLastLevel())
        {
            currentState = State.GameFinished;
        }
        else
        {
            currentState = State.LevelFinished;
            await LevelLoader.Instance.LoadNextLevel();
        }
    }
}