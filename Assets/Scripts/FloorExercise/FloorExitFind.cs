using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorExitFind : MonoBehaviour
{
    // This method is called when another collider makes contact with this object's collider
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Exit Reached!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        }
    }
}
