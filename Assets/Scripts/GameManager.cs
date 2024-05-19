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
    [SerializeField] private LevelFinishedMenu levelFinishedMenu;
    [SerializeField] private GameFinishedMenu gameFinishedMenu;
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private CameraFollow cam;

    private async void Awake()
    {
        Instance = this;
        await LevelLoader.Instance.Continue();
        Loading.Instance.SetActive(false);
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

    public void LevelFinished()
    {
        if (LevelLoader.Instance.IsLastLevel())
        {
            currentState = State.GameFinished;
            LevelLoader.Instance.ResetLevel();
            gameFinishedMenu.Toggle(true);
        }
        else
        {
            currentState = State.LevelFinished;
            cam.ToggleFollow(true);
            levelFinishedMenu.Toggle(true);
            player.transform.position = Vector3.zero;
        }
    }
}