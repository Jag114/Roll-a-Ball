using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private GameObject player;
    private LinkedList<Vector3> positionHistory;
    private int timeFlow;//1 = forwards / -1 = backwards
    private ParticleSystem particleSystem;
    private float timeDelay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        positionHistory = new LinkedList<Vector3>();
        timeFlow = 1;
        timeDelay = 0;
        particleSystem = FindFirstObjectByType<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && timeDelay > 1)
        {
            timeFlow = timeFlow * -1;
            timeDelay = 0;
        }
        else if(timeFlow == 1)
        {
            //print("adding position");
            Time.timeScale = 1;
            if(positionHistory.Count > 300)
            {
                positionHistory.RemoveFirst();
            }
            positionHistory.AddLast(player.transform.position);
        }
        else if(positionHistory.Count > 0 && timeFlow == -1)
        {
            //print("turning back time");
            particleSystem.Play();
            player.transform.position = positionHistory.Last.Value;
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
            positionHistory.RemoveLast();
        }
        
        if(positionHistory.Count == 0)
        {
            print("time reset");
            timeFlow = 1;
            Time.timeScale = 1;
        }

        timeDelay += Time.deltaTime;
    }
}
