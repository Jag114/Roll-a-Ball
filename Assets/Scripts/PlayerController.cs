using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb = default;
    private Vector3 movementVector = Vector3.zero;
    private List<Item> items = new List<Item>();
    private bool reset = false;

    public GameObject gameMaster = default;
    public int scoreThreshold = 0;
    public float speed = 1f;
    public float drag = 0f;
    public Camera camera;

    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        if(reset)
        {
            GameController.Instance.Teleport();
            reset = false;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVector * speed);
    }

    private void GetInput() 
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down keys

        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;

        movementVector = (forward * vertical + right * horizontal).normalized;

        if(Input.GetKeyDown(KeyCode.R))
        {
            reset = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            
            GameController.Instance.finished = true;
        }
    }

    public void AddToInventory(Item newItem)
    {
        print("ADDED TO EQ");
        items.Add(newItem);
    }

    public void OpenDoor(GameObject door, int id)
    {
        foreach (var item in items)
        {
            if (item.doorID == id)
            {
                door.GetComponent<Animation>().Play();
                items.Remove(item);
            }
            else
            {
                print("BAD KEY");
            }
        }
    }
}
