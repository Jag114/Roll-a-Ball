using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb = default;
    private Vector3 movementVector = Vector3.zero;
    private GameObject game_master = default;

    public int score_threshold = 0;
    public float speed = 1f;
    public float drag = 0f;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        game_master = GetComponent<GameObject>();
    }

    void Update()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            game_master.gameObject.GetComponent<GameController>().finished = true;
        }
    }
}
