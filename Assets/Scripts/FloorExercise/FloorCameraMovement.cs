using UnityEngine;

public class FloorCameraMovement : MonoBehaviour
{
    // Public Attributes
    public Transform playerTransform; // Reference to the player's Transform component

    // Private Properties
    private Transform cameraTransform; // Reference to the camera's Transform component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the camera's Transform component
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the camera's position to follow the player with a fixed offset.
        GetComponent<Transform>().position = new Vector3(playerTransform.position.x, cameraTransform.position.y, playerTransform.position.z);
    }
}
