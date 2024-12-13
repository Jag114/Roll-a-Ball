using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TimeManagaer timeManager;
    private DimensionManager dimensionManager;
    private UIManager uiManager;
    private static GameManager _instance = null;
    private float currentTimeScale = 1.0f;
    private int currentScore = -1;
    private int currentDimension = -1;
    private int currentScene;

    public static GameManager Instance { 
        get 
        {
            return _instance;
        } 
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        try
        {
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            timeManager = GameObject.Find("TimeManagaer").GetComponent<TimeManagaer>();
            dimensionManager = GameObject.Find("DimensionManager").GetComponent<DimensionManager>();
            uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        }
        catch (System.Exception e)
        {
            System.Console.Error.WriteLine(e.Message);
        }
    }

    private void Update()
    {
        //scoreManager gives info about reached score, notify UI

        //if UI wants to change scene

    }
}
