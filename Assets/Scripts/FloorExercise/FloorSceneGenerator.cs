using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FloorSceneGenerator : MonoBehaviour
{
    // Plublic Attributes
    public GameObject exitDoor; // Reference to the exit door GameObject
    [Range(20, 100)]
    public int numberOfFakeBlocks = 50; // Total number of blocks to be placed
    public GameObject[] floorBlocks = new GameObject[3]; // Array to hold different types of floor blocks

    // Private Attributes
    private List<int> fakeBlockIndexes = new List<int>(); // Array to hold indices for floor block types
    private int blockCounter = 0; // Counter for the number of blocks placed
    private int selectedFakeBlockIndex = 1; // Index for selecting fake block type
    private int exitDoorWallIndex; // Index for the wall where the exit door will be placed
    private int exitDoorPosition; // Position along the wall for the exit door

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Select a random wall index for the exit door (0: North, 1: East, 2: South, 3: West) and a random position along that wall
        exitDoorWallIndex = Random.Range(0, 4);
        exitDoorPosition = Random.Range(0, 25);
        // Position the exit door based on the selected wall and position
        switch (exitDoorWallIndex)
        {
            case 0: // North Wall4
                exitDoor.transform.position = new Vector3((2 * exitDoorPosition) + 1,0.5f,50.4f);
                break;
            case 1: // East Wall3
                exitDoor.transform.position = new Vector3(50.4f, 0.5f, (2 * exitDoorPosition) + 1);
                break;
            case 2: // South Wall1
                exitDoor.transform.position = new Vector3((2 * exitDoorPosition) + 1, 0.5f, -0.4f);
                break;
            case 3: // West Wall2
                exitDoor.transform.position = new Vector3(-0.4f, 0.5f, (2 * exitDoorPosition) + 1);
                break;
        }

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
                Vector3 position = new Vector3((i * 2.0f + 1f), -0.5f, (j * 2.0f + 1f)); // Calculate block position
                // Check if the current block index is in the list of fake block indexes
                if (fakeBlockIndexes.Contains(blockCounter))
                {
                    selectedFakeBlockIndex = Random.Range(1, 3); // Randomly select between fake block types
                    GameObject CreatedBlock = Instantiate(floorBlocks[selectedFakeBlockIndex], position, Quaternion.identity);
                    CreatedBlock.name = "FakeBlock" + selectedFakeBlockIndex + "_" + blockCounter;
                }
                else // Create a real block
                {
                    GameObject CreatedBlock = Instantiate(floorBlocks[0], position, Quaternion.identity);
                    CreatedBlock.name = "RealBlock_" + blockCounter;
                }
            }
        }
    }
}
