using System.Collections;
using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    [SerializeField] float minRepeatTime = 20;
    [SerializeField] float maxRepeatTime = 60;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    private AudioSource powerupMusic;
    [SerializeField] GameObject HUD;
    private AudioSource levelMusic;
    [SerializeField] float powerupTimer = 8;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        StartCoroutine("SpawnPowerup");
        powerupMusic = GetComponent<AudioSource>();
        levelMusic = HUD.GetComponent<AudioSource>();
    }

    IEnumerator SpawnPowerup()
    {
        while (!playerCollisionManager.gameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
        }
        yield return null;
    }

    internal IEnumerator PowerupMusic()
    {
        levelMusic.enabled = false;
        powerupMusic.enabled = true;
        yield return new WaitForSeconds(powerupTimer);
        levelMusic.enabled = true;
        powerupMusic.enabled = false;
    }
}
