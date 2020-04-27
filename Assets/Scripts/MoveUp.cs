using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] float speed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
