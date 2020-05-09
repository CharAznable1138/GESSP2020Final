using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float speed = 10;
    [SerializeField] float boundary = 20;
    [SerializeField] float powerupSpeedIncrementer = 10;
    [SerializeField] float powerupTimer = 8;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, 0);
        if(transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }

    }

    internal IEnumerator Powerup()
    {
        speed += powerupSpeedIncrementer;
        yield return new WaitForSeconds(powerupTimer);
        speed -= powerupSpeedIncrementer;
        yield return null;
    }
}
