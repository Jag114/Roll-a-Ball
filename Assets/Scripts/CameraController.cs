using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 5.0f;
    public float rotationSpeed = 5.0f;

    private Vector3 offset = Vector3.zero;
    private Vector2 rotation = Vector2.zero;

    private void Start()
    {
        offset = new Vector3(0, 2.0f, -distance);
    }

    private void LateUpdate()
    {
        if (player == null) return;

        // Handle rotation based on mouse movement
        rotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        rotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rotation.y = Mathf.Clamp(rotation.y, -20f, 60f);

        Quaternion rotationQuaternion = Quaternion.Euler(rotation.y, rotation.x, 0);

        transform.position = player.position + rotationQuaternion * offset;
        transform.LookAt(player.position + Vector3.up);
    }
}
