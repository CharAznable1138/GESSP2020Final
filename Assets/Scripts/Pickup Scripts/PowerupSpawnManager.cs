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
    [SerializeField] GameObject musicManagerObject;
    private MusicManager musicManager;
    [SerializeField] GameObject dialogueManagerObject;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        StartCoroutine("SpawnPowerup");
        powerupMusic = GetComponent<AudioSource>();
        levelMusic = HUD.GetComponent<AudioSource>();
        musicManager = musicManagerObject.GetComponent<MusicManager>();
    }

    IEnumerator SpawnPowerup()
    {
        while (!dialogueManager.IsDialogueOver)
        {
            yield return null;
        }
        while (!playerCollisionManager.GameOver)
        {
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnPosZ);
            Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
        }
        enabled = false;
        yield return null;
    }

    internal IEnumerator PowerupMusic()
    {
        levelMusic.enabled = false;
        powerupMusic.enabled = true;
        musicManager.SetPowerupMusic();
        yield return new WaitForSeconds(powerupTimer);
        levelMusic.enabled = true;
        powerupMusic.enabled = false;
        musicManager.SetLevelMusic();
    }
}
