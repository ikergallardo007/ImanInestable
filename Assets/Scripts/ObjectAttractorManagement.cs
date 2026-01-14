using UnityEngine;
using System.Collections.Generic;

public class ObjectAttractorManagement : MonoBehaviour
{
    // Public Attributes
    public float attractionForce = 10f; // Force applied to attract the object towards the player
    public PlayerController playerController; // Reference to the PlayerController script

    // Private Properties
    private Transform playerTransform; // Reference to the player's Transform component
    private int objectsCollected = 0; // Counter for collected objects
    private List<Rigidbody> attachedObjectsRigidbodies = new List<Rigidbody>(); // Array to hold attached objects
    private int attractionMultiplier; // Multiplier for attraction force based on player state

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player GameObject by its tag and get its Transform component
        playerTransform = GetComponent<Transform>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. It is used for physics calculations.
    private void FixedUpdate()
    {
        // Apply a stronger repulsion force to all attached objects if more than 3 objects are collected
        if (objectsCollected > 3)
        {
            foreach (Rigidbody rigidbody in attachedObjectsRigidbodies)
            {
                Vector3 direction = playerTransform.position - rigidbody.GetComponent<Transform>().position;
                rigidbody.GetComponent<Rigidbody>().AddForce((-1) * 50 * direction.normalized * attractionForce / direction.magnitude); // Apply stronger repulsion force inversely proportional to distance
            }
        }
    }

    // OnTriggerEnter is called when a metallic collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Metal" tag to add it to the collected objects
        if (other.gameObject.CompareTag("Metal"))
        {
            objectsCollected++; // Increment the counter when an object enters the trigger
            attachedObjectsRigidbodies.Add(other.GetComponent<Rigidbody>());
            print(other.gameObject.name + " entered. Total collected: " + objectsCollected);
        }
    }

    // OnTriggerStay is called once per frame while a metallic object collider is within the trigger collider
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Metal"))
        {
            if (playerController.atractionOn)
            {
                attractionMultiplier = 1;
            }
            else
            {
                attractionMultiplier = -1;
            }
            Vector3 direction = playerTransform.position - other.GetComponent<Transform>().position; // Direction vector from the object to the player
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * attractionForce * attractionMultiplier / direction.magnitude); // Apply attraction force inversely proportional to distance
        }
    }

    // OnTriggerExit is called when a metallic collider exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the "Metal" tag to remove it from the collected objects
        if (other.gameObject.CompareTag("Metal"))
        {
            objectsCollected--; // Decrement the counter when an object exits the trigger
            attachedObjectsRigidbodies.Remove(other.GetComponent<Rigidbody>());
            print(other.gameObject.name + " exited. Total collected: " + objectsCollected);
        }

    }
}
