using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Attributes
    public Rigidbody playerRigidbody; // Reference to the player's Rigidbody component

    public GameObject[] metallicObject = new GameObject[5]; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Instantiate 8 random metallic objects at random positions within the range (5,100) for x and z coordinates.
        for (int i = 0; i < 8; i++)
        {
            GameObject CreatedObject = Instantiate(metallicObject[Random.Range(0, 5)]);
            CreatedObject.transform.position = new Vector3(Random.Range(5,100), 0, Random.Range(5, 100));
            CreatedObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
