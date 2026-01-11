using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    private Rigidbody playerRigidbody;
    public float playerSpeed;
    private Vector3 movementDirection;


    public InputAction move;
    public InputAction attack;

    //public InputActionReference move;
    //public InputManagerEntry attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = move.ReadValue<Vector3>();
        print(movementDirection);
        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    print(Input.GetAxis("Horizontal"));
        //}
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector3(movementDirection.x * playerSpeed, movementDirection.y * playerSpeed, movementDirection.z * playerSpeed);
    }
}
