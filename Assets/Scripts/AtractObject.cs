using UnityEngine;

public class AtractObject : MonoBehaviour
{
    // Public Attributes
    public float attractionForce = 10f; // Force applied to attract the object towards the player

    // Private Properties
    private Transform playerTransform; // Reference to the player's Transform component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player GameObject by its tag and get its Transform component
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Metal"))
        {
            Vector3 direction = playerTransform.position - other.GetComponent<Transform>().position;
            print("Direction vector: " + direction + "Distance: " + direction.magnitude + "Force: " + (direction.normalized * attractionForce / direction.magnitude).magnitude);
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * attractionForce / direction.magnitude);
        }
    }
}
