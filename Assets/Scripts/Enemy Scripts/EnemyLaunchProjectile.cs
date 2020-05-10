using System.Collections;
using UnityEngine;

public class EnemyLaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float minRepeatTime = 0.5f;
    [SerializeField] float maxRepeatTime = 1.5f;
    private GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    private AudioSource firingNoise;

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
        }
    }
}
