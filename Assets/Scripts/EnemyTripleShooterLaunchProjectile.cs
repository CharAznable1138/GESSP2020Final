using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTripleShooterLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minRepeatTime = 0.5f;
    [SerializeField] float maxRepeatTime = 1.5f;
    private AudioSource firingNoise;
    [SerializeField] GameObject bulletSpawnerLeft;
    [SerializeField] GameObject bulletSpawnerRight;

    // Start is called before the first frame update
    void Start()
    {
        firingNoise = GetComponent<AudioSource>();
        StartCoroutine("LaunchProjectile");
    }

    IEnumerator LaunchProjectile()
    {
        while (true)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), bulletSpawnerLeft.transform.rotation);
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), bulletSpawnerRight.transform.rotation);
        }
    }
}
