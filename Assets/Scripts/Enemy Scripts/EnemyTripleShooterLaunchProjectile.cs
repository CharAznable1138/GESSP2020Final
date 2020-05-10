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
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bulletPrefab, new Vector3(bulletSpawnerLeft.transform.position.x, bulletSpawnerLeft.transform.position.y, bulletSpawnerLeft.transform.position.z), bulletSpawnerLeft.transform.rotation);
            Instantiate(bulletPrefab, new Vector3(bulletSpawnerRight.transform.position.x, bulletSpawnerRight.transform.position.y, bulletSpawnerRight.transform.position.z), bulletSpawnerRight.transform.rotation);
        }
    }
}
