using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody m_rb;
    float m_thrust = 4f;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move("S");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move("D");
        }
    }

    void Move(string code)
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.AddForce(0, 0, 1 * m_thrust);
            //Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_rb.AddForce(0, 0, -1 * m_thrust);
            //Debug.Log("S");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(-1 * m_thrust, 0, 0);
            //Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(1 * m_thrust, 0, 0);
            //Debug.Log("D");
        }
    }
}
