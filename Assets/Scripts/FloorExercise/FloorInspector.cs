using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FloorInspector : MonoBehaviour
{
    // Plublic Attributes
    public Camera cameraPlayer; // Reference to the camera
    public Transform focusedBlock = null; // Currently focused block
    public GameObject playerObject; // Reference to the player object

    // Private Attributes
    private InputAction interactionAction; // Input action for changing magnetism

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionAction = InputSystem.actions.FindAction("Interact"); // Find the interaction action
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue(); // Get the current mouse position
        RaycastHit hit;

        // Create a ray from the camera through the mouse position
        Ray ray = cameraPlayer.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(cameraPlayer.transform.position, hit.point, Color.blue); // Draw a debug line to visualize the raycast
            Vector3 playerPosition = new Vector3(playerObject.transform.position.x, 0 , playerObject.transform.position.z); // Player position on the XZ plane
            float distance = Vector3.Distance(playerPosition, hit.point); // Distance from player to the hit point
            if (distance < 2.5) // The player can only inspect blocks within 2.5 units
            {
                // Highlight the block when looked at
                focusedBlock = hit.transform;

                // Inspect the block when the interaction action is pressed
                if (interactionAction.IsPressed())
                {
                    // Change the color of the block based on its tag
                    switch (hit.transform.tag)
                    {
                        case "RealBlock":
                            hit.transform.GetComponent<Renderer>().material.color = Color.green;
                            break;
                        case "FakeBlock1":
                            hit.transform.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        case "FakeBlock2":
                            hit.transform.GetComponent<Renderer>().material.color = Color.orange;
                            break;
                        default:
                            break;
                }
                }
            }
            else
            {
                focusedBlock = null;
            }
        }
    }
}
