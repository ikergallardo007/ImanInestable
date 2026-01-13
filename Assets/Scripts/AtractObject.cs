using UnityEngine;

public class AtractObject : MonoBehaviour
{
    // Public Attributes
    public Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Metallic"))
        {
            Vector3 direction = playerRigidbody.position - other.attachedRigidbody.position;
            other.attachedRigidbody.AddForce(direction.normalized * 10f);
        }
    }
}
