using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachineGunnerLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minRepeatTime = 0.5f;
    [SerializeField] float maxRepeatTime = 1.5f;
    private AudioSource firingNoise;
    [SerializeField] float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        firingNoise = GetComponent<AudioSource>();
        StartCoroutine("LaunchProjectile");
    }

    IEnumerator LaunchProjectile()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
