using UnityEngine;

//Credit to Prof. Michael Hadley for informing me of the existence of ScreenToWorldPoint
//Credit to Unity documentation for informing me how to use ScreenToWorldPoint

public class RotateTurret : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10;
    [SerializeField] float turnLimit = 45;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y)));
    }
}
