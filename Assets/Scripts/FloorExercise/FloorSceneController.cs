using UnityEngine;
using System.Collections.Generic;

public class FloorSceneController : MonoBehaviour
{
    // Plublic Attributes
    public GameObject[] floorBlocks = new GameObject[2]; // Array to hold different types of floor blocks
    [Range(20, 100)]
    public int numberOfFakeBlocks = 50; // Total number of blocks to be placed

    // Private Attributes
    private List<int> fakeBlockIndexes = new List<int>(); // Array to hold indices for floor block types
    private int blockCounter = 0; // Counter for the number of blocks placed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfFakeBlocks; i++)
        {
            int randomIndex = Random.Range(1, 625);
            print("Random Index: " + randomIndex);
            fakeBlockIndexes.Add(randomIndex);
        }

        print("Fake Block Indexes: " + fakeBlockIndexes);

        // Initialize floor blocks randomly
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                blockCounter++;
                Vector3 position = new Vector3((i * 2.0f + 1f), -0.5f, (j * 2.0f + 1f));
                if (fakeBlockIndexes.Contains(blockCounter))
                {
                    Instantiate(floorBlocks[1], position, Quaternion.identity);
                }
                else
                {
                    Instantiate(floorBlocks[0], position, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
