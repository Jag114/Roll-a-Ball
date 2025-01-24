using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private float gameTime;
    private static GameController gameControllerInstance = null;

    public MusicController musicController = null;
    public static GameController Instance { 
        get {
            if(gameControllerInstance == null)
            {
                gameControllerInstance = new GameController();
            }
            return gameControllerInstance;
        } 
    }
    public bool finished = false;
    public int scoreThreshold = 5;
    public Text scoreText = null;
    public Text finishText = null;
    public Text timeText = null;
    public GameObject levelSelectPanel;
    public GameObject optionsPanel;
    public event Action scoreUpdate;

    public Vector3 lastCheckpointPosition = Vector3.zero;
    public event Action<Vector3> OnTeleportRequest;

    private void Awake()
    {
        if(gameControllerInstance == null)
        {
            gameControllerInstance = this;
            if(musicController == null)
            {
                musicController = FindAnyObjectByType<MusicController>();
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        print(Time.timeScale);
        scoreUpdate += CheckFinish;
        if (lastCheckpointPosition == Vector3.zero)
        {
            lastCheckpointPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        if (timeText == null) timeText = GameObject.Find("TimeText")?.GetComponent<Text>();
        if (finishText == null) timeText = GameObject.Find("FinishText")?.GetComponent<Text>();
        if (scoreThreshold == 0) scoreText.text = "";
    }

    private void OnDestroy()
    {
        scoreUpdate -= CheckFinish;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if(timeText != null)
        {
            timeText.text = "Time: " + gameTime;
        }

        if (finished)
        {
            Time.timeScale = 0;
            if (finishText != null)
            {
                finishText.gameObject.SetActive(true);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                score = 0;
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(++index, LoadSceneMode.Single);
                finished = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    private void CheckFinish()
    {
        if(scoreThreshold > 0 && score == scoreThreshold) 
        {
            finished = true;
        }
    }

    public void SetLastCheckpoint(Vector3 checkpoint) 
    {
        lastCheckpointPosition = checkpoint;
        print("Checkpoint set");
    }

    public void Teleport()
    {
        print("Teleport req");
        OnTeleportRequest?.Invoke(lastCheckpointPosition);
    }

    public void IncrementScore(int point)
    {
        if (score <= scoreThreshold)
        {
            score += point;
        }
        scoreUpdate?.Invoke();
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void StartGame(int lvl)
    {
        SceneManager.LoadScene(lvl, LoadSceneMode.Single);
    }

    public void OpenLevelSelectionWindow()
    {
        levelSelectPanel.gameObject.SetActive(true);
    }

    public void ShowOptions(bool isActive)
    {
        optionsPanel.SetActive(isActive);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
