using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private bool finished = false;
    private float m_thrust = 4f;
    private int score = 0;
    private Rigidbody rb = null;
    private Queue<Vector3> movementVectorQueue;

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
        movementVectorQueue = new Queue<Vector3>();
    }

    void Update()
    {
        GetInput();
        CheckFinish();
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVectorQueue.Dequeue());
    }

    private void GetInput()
    {
        //axis?
        if (Input.GetKey(KeyCode.W))
        {
            movementVectorQueue.Enqueue(new Vector3(0, 0, 1 * m_thrust * speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementVectorQueue.Enqueue(new Vector3(0, 0, -1 * m_thrust * speed));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementVectorQueue.Enqueue(new Vector3(-1 * m_thrust * speed, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementVectorQueue.Enqueue(new Vector3(1 * m_thrust * speed, 0, 0));
        }
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
