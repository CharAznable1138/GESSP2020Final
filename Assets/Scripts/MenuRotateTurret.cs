using UnityEngine;

public class MenuRotateTurret : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10;
    [SerializeField] float turnLimit = 45;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);

        if(transform.rotation.y >= turnLimit || transform.rotation.y < 0)
        {
            turnSpeed *= -1;
        }

    }
}
