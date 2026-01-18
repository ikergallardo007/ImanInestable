using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FloorInspector : MonoBehaviour
{
    // Plublic Attributes
    public Camera camera;
    public Rigidbody selectedBlock = null;
    public GameObject playerObject;

    // Private Attributes
    private InputAction interactionAction; // Input action for changing magnetism

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(camera.transform.position, hit.point, Color.blue);
            Vector3 playerPosition = new Vector3(playerObject.transform.position.x, 0 , playerObject.transform.position.z);
            float distance = Vector3.Distance(playerPosition, hit.point);
            if (distance < 2.5)
            {
                //highlight the block when looked at
                // Inspect the block when the interaction action is pressed
                if (interactionAction.IsPressed())
                {
                    print("Inspecting the block.");
                    switch (hit.transform.tag)
                    {
                        case "RealBlock":
                            hit.transform.GetComponent<Renderer>().material.color = Color.green;
                            print("This is a Real Block.");
                            break;
                        case "FakeBlock1":
                            hit.transform.GetComponent<Renderer>().material.color = Color.red;
                            print("This is a Fake Block Type 1.");
                            break;
                        case "FakeBlock2":
                            hit.transform.GetComponent<Renderer>().material.color = Color.orange;
                            print("This is the Fake Block Type 2.");
                            break;
                        default:
                            print("Unknown object.");
                            break;
                }
                }
                //        if (selectedBlock != null)
                //        {
                //            selectedBlock.GetComponent<Renderer>().material.color = Color.white;
                //        }
                //        selectedBlock = hit.rigidbody;
                //        selectedBlock.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
