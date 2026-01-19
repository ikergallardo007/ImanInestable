using UnityEngine;
using UnityEngine.InputSystem;

public class FloorPlayerController : MonoBehaviour
{

    // Public Attributes
    public Rigidbody playerRigidbody; // Reference to the player's Rigidbody component
    public Transform resetPoint; // Reference to the reset point Transform component

    // Private Properties
    private float force = 300f; // Force applied for movement
    private InputAction moveAction; // Input action for movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the move action from the Input System
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRigidbody.position.y < -5f)
        {
            // Reset the player's position if they fall below a certain height
            playerRigidbody.position = resetPoint.position; // Reset position to the reset point
            playerRigidbody.linearVelocity = Vector3.zero; // Reset velocity to avoid carrying over momentum
            playerRigidbody.angularVelocity = Vector3.zero; // Reset angular velocity
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    void FixedUpdate()
    {
        // Read the movement input value and apply force to the Rigidbody
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveValue.x, 0, moveValue.y);
        playerRigidbody.AddForce(movement * force);
    }
}
