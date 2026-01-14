using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    // Public Attributes
    public Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    // Private Properties
    private float force = 250f; // Force applied for movement
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
