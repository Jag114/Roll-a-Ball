using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public float coordX = 0;
    public float coordY = 0;
    public float coordZ = 0;

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.transform.position = new Vector3(coordX, coordY, coordZ);
        collision.rigidbody.linearVelocity = new Vector3(0, 0, 0);
    }
}
