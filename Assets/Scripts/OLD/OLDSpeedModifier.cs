using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OLDBooster : MonoBehaviour
{
    public float speed = 1;
    public float drag = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Speed changed to " + speed);
        Debug.Log("Drag changed to " + drag);
        OLDMovementController player = collision.gameObject.GetComponent<OLDMovementController>();
        player.speed = speed;
        player.GetComponent<Rigidbody>().linearDamping = drag;
    }
}
