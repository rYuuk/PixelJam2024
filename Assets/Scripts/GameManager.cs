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
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameOverMenu gameOverMenu;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private CameraFollow cam;
    [SerializeField] private BubbleController bubbleController;

    private bool isTutorialShown;
    private async void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("FirstTime", 0) == 0)
        {
            tutorial.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);
            isTutorialShown = true;
        }

        await LevelLoader.Instance.Continue();
        var level = LevelLoader.Instance.GetLevel();
        bubbleController.ActivateIcons(level);
        player.GetComponent<Friends>().Toggle(level);

        Loading.Instance.SetActive(false);
        currentState = State.Running;
    }

    private void Update()
    {
        if (currentState == State.Running && Input.GetKeyUp(KeyCode.Escape))
        {
            pauseMenu.Toggle();
        }

        if (isTutorialShown && Input.anyKeyDown)
        {
            tutorial.SetActive(false);
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
            AudioController.Instance.PlayGameCompleteMusic();
            currentState = State.GameFinished;
            LevelLoader.Instance.ResetLevel();
            gameFinishedMenu.Toggle(true);
            bubbleController.ActivateAll();
        }
        else
        {
            var nextLevel = LevelLoader.Instance.GetLevel() + 1;
            player.GetComponent<Friends>().Toggle(nextLevel);
            bubbleController.ActivateIcons(nextLevel);
            AudioController.Instance.PlayLevelMusic();
            currentState = State.LevelFinished;
            cam.ToggleFollow(true);
            levelFinishedMenu.Toggle(true);
            player.transform.position = Vector3.zero;
        }
    }
}