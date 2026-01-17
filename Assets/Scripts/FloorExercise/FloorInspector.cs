using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FloorInspector : MonoBehaviour
{
    // Plublic Attributes
    public Camera camera;
    public Rigidbody selectedBlock = null;

    // Private Attributes

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mousePosition3D = new Vector3(mousePosition.x, 0, mousePosition.y);
        RaycastHit hit;

        Ray ray = camera.ScreenPointToRay(mousePosition3D);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(camera.transform.position, hit.point, Color.blue);
            //if (hit.rigidbody != null && hit.rigidbody.tag == "FloorBlock")
            //{
            //    if (selectedBlock != null)
            //    {
            //        selectedBlock.GetComponent<Renderer>().material.color = Color.white;
            //    }
            //    selectedBlock = hit.rigidbody;
            //    selectedBlock.GetComponent<Renderer>().material.color = Color.red;
            //}
        }
    }
}
