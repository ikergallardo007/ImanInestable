using System.Timers;
using UnityEngine;

public class FloorPlayerTouch : MonoBehaviour
{
    // Public Attributes
    public Transform floorBlockTransform; // Reference to the floor block's Transform component

    // Private Properties
    public bool timerStart = false; // Flag to indicate if the timer has started
    private float timer = 1f; // Timer to track time since the block was touched

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches the block
        if (other.gameObject.CompareTag("Player"))
        {
            // Perform actions based on the block's tag
            switch (floorBlockTransform.transform.tag)
            {
                // Make FakeBlock1 fall immediately
                case "FakeBlock1":
                    floorBlockTransform.GetComponent<Rigidbody>().isKinematic = false; // Make the block fall
                    break;
                // Start the timer for FakeBlock2
                case "FakeBlock2":
                    timerStart = true;
                    if (timerStart)
                    {
                        timer = 1f; // Reset the timer
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the player touches the block
        if (other.gameObject.CompareTag("Player"))
        {
            // Handle the timer for FakeBlock2
            if (floorBlockTransform.transform.tag == "FakeBlock2")
            {
                if (timerStart)
                {
                    timer -= Time.deltaTime; // Decrease the timer
                    if (timer <= 0)
                    {
                        floorBlockTransform.GetComponent<Rigidbody>().isKinematic = false; // Make the block fall
                        timerStart = false; // Reset the timer flag
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timerStart = false; // Reset the timer flag
    }
}
