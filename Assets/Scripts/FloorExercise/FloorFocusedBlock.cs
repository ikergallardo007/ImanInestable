using UnityEngine;

public class FloorFocusedBlock : MonoBehaviour
{
    // Public Attributes
    public FloorInspector floorInspector;
    public Renderer blockRenderer;
    public bool inspectedBlock = false;

    // Private Attributes
    private Color originalColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = blockRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inspectedBlock)
        {
            if (floorInspector.focusedBlock != null && floorInspector.focusedBlock.name == blockRenderer.name)
            {
                print(blockRenderer.name + " is focused.");
                blockRenderer.material.color = Color.blue;
            }
            else
            {
                // Reset color when not focused
                blockRenderer.material.color = originalColor;
            }
        }
    }   
}
