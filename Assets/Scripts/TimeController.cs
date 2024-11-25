using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private GameObject player;
    private LinkedList<Vector3> positionHistory;
    private int timeFlow;//1 = forwards / -1 = backwards

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        positionHistory = new LinkedList<Vector3>();
        timeFlow = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timeFlow = timeFlow * -1;
            print("Pressed Space");
        }
        else if(positionHistory.Count <= 3000 && timeFlow == 1)
        {
            print("adding position");
            Time.timeScale = 1;
            positionHistory.AddLast(player.transform.position);
        }
        else if(positionHistory.Count > 0 && timeFlow == -1)
        {
            print("turning back time");
            Time.timeScale = 0;
            player.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
            player.transform.position = positionHistory.Last.Value;
            positionHistory.RemoveLast();
        }
        
        if(positionHistory.Count == 0)
        {
            print("reset");
            timeFlow = 1;
            Time.timeScale = 1;
        }
    }
}
