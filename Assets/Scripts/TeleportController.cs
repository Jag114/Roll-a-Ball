using System;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    private void Start()
    {
        GameController.Instance.OnTeleportRequest += HandleTeleport;
    }

    private void OnDestroy()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnTeleportRequest -= HandleTeleport;
        }
    }

    private void HandleTeleport(Vector3 targetPosition)
    {
        print("Handle tp");
        GameObject.FindGameObjectWithTag("Player").transform.position = targetPosition;
    }
}
