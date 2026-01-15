using UnityEngine;

public class FloorSceneController : MonoBehaviour
{
    // Plublic Attributes
    public GameObject[] floorBlocks = new GameObject[2]; // Array to hold different types of floor blocks

    // Private Attributes

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize floor blocks randomly
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Vector3 position = new Vector3((i * 2.0f + 1f), -0.5f, (j * 2.0f + 1f));
                Instantiate(floorBlocks[0], position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
