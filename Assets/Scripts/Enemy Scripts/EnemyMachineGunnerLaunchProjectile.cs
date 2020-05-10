using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMachineGunnerLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minRepeatTime = 0.5f;
    [SerializeField] float maxRepeatTime = 1.5f;
    private AudioSource firingNoise;
    [SerializeField] float burstDelay = 1.0f;
    [SerializeField] int maxBulletsPerBurst = 10;
    private GameObject player;
    private PlayerCollisionManager playerCollisionManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        firingNoise = GetComponent<AudioSource>();
        StartCoroutine("LaunchProjectile");
    }

    IEnumerator LaunchProjectile()
    {
        while (!playerCollisionManager.GameOver)
        {
            yield return new WaitForSeconds(burstDelay);
            int bulletsLaunched = 0;
            while (bulletsLaunched < maxBulletsPerBurst)
            {
                float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
                yield return new WaitForSeconds(waitTime);
                firingNoise.Play();
                Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                bulletsLaunched++;
            }
        }
    }
}
