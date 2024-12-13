using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 movementVector = Vector3.zero;
    private float unmodifiedMovementSpeed;
    private float speedModifier = 1f;
    private float speedModifierDuration = 0f;

    public float movementSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        unmodifiedMovementSpeed = movementSpeed;
    }

    void Update()
    {
        //GetInput();
    }

    private void FixedUpdate()
    {
        if(speedModifierDuration > 0)
        {
            movementSpeed *= speedModifier;
            speedModifierDuration -= Time.fixedDeltaTime;
        }
        rigidBody.AddForce(movementVector * movementSpeed);
    }

    public void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right keys
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down keys
        movementVector = new Vector3(horizontal, 0, vertical);
    }

    public void SpeedModify(float duration, float force)
    {
        speedModifierDuration = duration;
        speedModifier = force;
    }
}
