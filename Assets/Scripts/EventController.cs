using UnityEngine;

public class EventController : MonoBehaviour
{
    GameObject bridge;
    
    private void Start()
    {
        bridge = GameObject.FindGameObjectWithTag("Activatable");
        bridge.SetActive(false);    
    }

    private void OnCollisionEnter(Collision collision)
    {
        bridge.SetActive(true);
    }
}
