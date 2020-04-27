using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] float boundary = 30;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > boundary)
        {
            Destroy(gameObject);
        }
        if(transform.position.z < -boundary)
        {
            Destroy(gameObject);
        }
        if(transform.position.x > boundary)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < -boundary)
        {
            Destroy(gameObject);
        }
    }
}
