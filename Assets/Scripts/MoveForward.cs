using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    internal float Speed { get { return speed; } set { speed = value; } }
}
