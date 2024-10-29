using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OLDMovementController : MonoBehaviour
{
    private Rigidbody m_rb;
    private bool finished = false;
    float m_thrust = 4f;
    public int score;
    private bool applyForce;
    public Text score_text;
    public Text finish_text;
    public Text time_text;
    private float game_time;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        score = 0;
        applyForce = false;
        game_time = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        game_time += Time.deltaTime;
        time_text.text = "Time: " + game_time;

        if (finished)
        {
            Time.timeScale = 0;
            Debug.Log("FINISHED");
            if (Input.GetKey(KeyCode.Space))
            {
                int index = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(++index, LoadSceneMode.Single);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.AddForce(0, 0, 1 * m_thrust * speed);
            //Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_rb.AddForce(0, 0, -1 * m_thrust * speed);
            //Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(-1 * m_thrust * speed, 0, 0);
            //Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(1 * m_thrust * speed, 0, 0);
            //Debug.Log("D");
        }
    }

    public void CollectScore()
    {
        score++;
        score_text.text = "Score: " + score;
        print(score);
        if(score >= 5)
        {
            //gameObject.SetActive(false);
            finish_text.gameObject.SetActive(true);
            finished = true;
        }
    }
}

