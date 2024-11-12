using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool finished = false;
    private int score = 0;
    public int score_threshold = 5;

    private float game_time;
    public Text score_text;
    public Text finish_text;
    public Text time_text;
    public GameObject level_select_panel;
    public GameObject options_panel;
    private GameController game_controller;

    void Start()
    {
        if (score_threshold == 0) score_text.text = "";    
    }

    // Update is called once per frame
    void Update()
    {
        CheckFinish();
        game_time += Time.deltaTime;
        time_text.text = "Time: " + game_time;
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
            finish_text.gameObject.SetActive(true);
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
