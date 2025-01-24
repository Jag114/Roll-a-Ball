using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 checkpointLocation;
    public bool killZone = false;

    private void Start()
    {
        if (!killZone)
        {
            checkpointLocation = transform.position;
        }
        else
        {
            checkpointLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (killZone)
            {
                GameController.Instance.Teleport();
            }
            else
            {
                GameController.Instance.SetLastCheckpoint(checkpointLocation);
            }
                print("Set checkpoint to " + checkpointLocation);
        }
    }
}