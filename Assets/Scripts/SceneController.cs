using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Attributes
    public Rigidbody playerRigidbody;

    public GameObject[] metallicObject = new GameObject[2]; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject CreatedObject = Instantiate(metallicObject[Random.Range(0, 1)]);
            CreatedObject.transform.position = new Vector3(Random.Range(5,100), 0, Random.Range(5, 100));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
