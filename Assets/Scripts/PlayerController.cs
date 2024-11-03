using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool finished = false;
    private int score = 0;
    private Rigidbody rb = null;
    private Vector3 movementVector = Vector3.zero;

    public int score_threshold = 0;
    public float speed = 1f;
    public float drag = 0f;

    //UI
    //public Text score_text;
    //private float game_time;
    //public Text finish_text;
    //public Text time_text;

    //UI - update
    //game_time += Time.deltaTime;
    //time_text.text = "time: " + game_time;


    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckFinish();
        GetInput();
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVector * speed);
    }

    private void GetInput() 
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down keys
        movementVector = new Vector3(horizontal, 0, vertical);
    }

    private void CheckFinish()
    {
        if (finished)
        {
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(++index, LoadSceneMode.Single);
            }
        }
    }

    public void IncrementScore()
    {
        if(score <= score_threshold)
        {
            score += 1;
        }
    }
}
