using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    InputAction moveAction;
    InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveValue.x, 0, moveValue.y);
        playerRigidbody.linearVelocity = movement * 5f + new Vector3(0, playerRigidbody.linearVelocity.y, 0);
        if (jumpAction.IsPressed())
        {
            playerRigidbody.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }
}
