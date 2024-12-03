using UnityEditor.SceneManagement;
using UnityEngine;
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
    public int score_threshold = 5;
    public Text score_text;
    public Text finish_text;
    public Text time_text;
    public GameObject level_select_panel;
    public GameObject options_panel;

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
        if (score_threshold == 0) score_text.text = "";    
    }

    void Update()
    {
        CheckFinish();
        gameTime += Time.deltaTime;
        if(time_text != null)
        {
            time_text.text = "Time: " + gameTime;
        }
    }

    private void CheckFinish()
    {
        if(score_threshold > 0 && score == score_threshold) 
        {
            finished = true;
        }

        if (finished)
        {
            Time.timeScale = 0;
            if(finish_text != null)
            {
                finish_text.gameObject.SetActive(true);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(++index, LoadSceneMode.Single);
            }
        }
    }

    public void IncrementScore()
    {
        if (score <= score_threshold)
        {
            score += 1;
        }
        score_text.text = "Score: " + score;
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
        level_select_panel.gameObject.SetActive(true);
    }

    public void ShowOptions(bool isActive)
    {
        options_panel.SetActive(isActive);
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
