using UnityEngine;
using System.Collections.Generic;

public class FloorSceneController : MonoBehaviour
{
    // Plublic Attributes
    public GameObject[] floorBlocks = new GameObject[3]; // Array to hold different types of floor blocks
    [Range(20, 100)]
    public int numberOfFakeBlocks = 50; // Total number of blocks to be placed

    // Private Attributes
    private List<int> fakeBlockIndexes = new List<int>(); // Array to hold indices for floor block types
    private int blockCounter = 0; // Counter for the number of blocks placed
    private int selectedFakeBlockIndex = 1; // Index for selecting fake block type

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generate unique random indexes for fake blocks
        for (int i = 0; i < numberOfFakeBlocks; i++)
        {
            int randomIndex = Random.Range(1, 625);
            if (fakeBlockIndexes.Contains(randomIndex) || randomIndex == 313) // Avoid duplicates and player's initial block
            {
                i--;
                continue;
            }
            fakeBlockIndexes.Add(randomIndex);
        }

        // Initialize floor blocks randomly
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                blockCounter++;
                Vector3 position = new Vector3((i * 2.0f + 1f), -0.5f, (j * 2.0f + 1f));
                if (fakeBlockIndexes.Contains(blockCounter))
                {
                    selectedFakeBlockIndex = Random.Range(1, 3);
                    print("Selected Fake Block Index: " + selectedFakeBlockIndex);
                    GameObject CreatedBlock = Instantiate(floorBlocks[selectedFakeBlockIndex], position, Quaternion.identity);
                    CreatedBlock.name = "FakeBlock_" + blockCounter;
                }
                else
                {
                    GameObject CreatedBlock = Instantiate(floorBlocks[0], position, Quaternion.identity);
                    CreatedBlock.name = "RealBlock_" + blockCounter;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
