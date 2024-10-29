using UnityEngine;

public class OLDBarrierController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        OLDMovementController player = collision.gameObject.GetComponent<OLDMovementController>();
        player.speed = 1f;
    }
}
