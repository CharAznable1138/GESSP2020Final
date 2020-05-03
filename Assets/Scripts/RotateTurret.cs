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
        //Two turn logics, old and new. Keeping the old in case I want to give players the option to toggle between the two later.

        //Old turn logic

        /*if (transform.rotation.y < -turnLimit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, -turnLimit, transform.rotation.z, transform.rotation.w);
        }

        if (transform.rotation.y > turnLimit)
        {
            transform.rotation = new Quaternion(transform.rotation.x, turnLimit, transform.rotation.z, transform.rotation.w);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }*/

        //New turn logic

        transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - transform.position.y)));

    }
}
