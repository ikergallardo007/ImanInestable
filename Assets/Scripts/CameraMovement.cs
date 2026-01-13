using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Public Attributes
    public Transform playerTransform; // Reference to the player's Transform component

    // Private Properties
    private Transform cameraTransform; // Reference to the camera's Transform component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(playerTransform.position.x, cameraTransform.position.y, playerTransform.position.z - 11);
    }
}
