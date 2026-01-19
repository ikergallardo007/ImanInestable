using UnityEngine;

public class MagnetSceneController
    : MonoBehaviour
{
    // Attributes
    public Rigidbody playerRigidbody; // Reference to the player's Rigidbody component
    public GameObject[] metallicObject = new GameObject[2];
    [Range(8, 12)]
    public int numberOfCubes = 8;
    [Range(4, 8)]
    public int numberOfCylindres = 8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Instantiate numberOfCubes metallic cube objects at random positions within the range (5,100) for x and z coordinates.
        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject CreatedObject = Instantiate(metallicObject[0]);
            CreatedObject.transform.position = new Vector3(Random.Range(5,100), 0, Random.Range(5, 100));
            CreatedObject.SetActive(true);
        }
        // Instantiate numberOfCubes metallic cube objects at random positions within the range (5,100) for x and z coordinates.
        for (int i = 0; i < numberOfCylindres; i++)
        {
            GameObject CreatedObject = Instantiate(metallicObject[1]);
            CreatedObject.transform.position = new Vector3(Random.Range(5,100), 0, Random.Range(5, 100));
            CreatedObject.SetActive(true);
        }
    }
}
