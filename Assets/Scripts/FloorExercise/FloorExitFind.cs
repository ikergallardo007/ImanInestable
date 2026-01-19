using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorExitFind : MonoBehaviour
{
    // Public Attributes

    // Private Properties

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Exit Reached!");
            // Additional logic for when the player reaches the exit can be added here
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
