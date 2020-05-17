using System.Collections;
using UnityEngine;

public class MedkitSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject medkitPrefab;
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    [SerializeField] float minRepeatTime = 10;
    [SerializeField] float maxRepeatTime = 20;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    [SerializeField] GameObject dialogueManagerObject;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        StartCoroutine("SpawnMedkit");
    }

    IEnumerator SpawnMedkit()
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
            Instantiate(medkitPrefab, spawnPos, medkitPrefab.transform.rotation);
        }
        yield return null;
    }
}
