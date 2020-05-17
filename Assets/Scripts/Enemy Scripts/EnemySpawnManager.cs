using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs = new GameObject[3];
    [SerializeField] float spawnRangeX = 20;
    [SerializeField] float spawnPosZ = 20.3f;
    [SerializeField] float spawnPosX = 20.3f;
    [SerializeField] float spawnRangeZPosi = 20;
    [SerializeField] float spawnRangeZNega = -10;
    [SerializeField] float minRepeatTime = 1;
    [SerializeField] float maxRepeatTime = 10;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    private int enemyPrefabIndex;
    [SerializeField] int maxSpecialEnemies;
    [SerializeField] GameObject dialogueManagerObject;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
        dialogueManager = dialogueManagerObject.GetComponent<DialogueManager>();
        StartCoroutine("SpawnEnemyTop");
        StartCoroutine("SpawnEnemyLeft");
        StartCoroutine("SpawnEnemyRight");
    }

    IEnumerator SpawnEnemyTop()
    {
        while(!dialogueManager.IsDialogueOver)
        {
            yield return null;
        }
        while (!playerCollisionManager.GameOver)
        {
            enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            if (enemyPrefabs[enemyPrefabIndex].gameObject.CompareTag("EnemySpecial"))
            {
                if(GameObject.FindGameObjectsWithTag("EnemySpecial").Length <= maxSpecialEnemies)
                {
                    Instantiate(enemyPrefabs[enemyPrefabIndex], spawnPos, enemyPrefabs[enemyPrefabIndex].transform.rotation);
                }
                else
                {
                    Debug.Log("Tried to spawn in a special enemy, failed because there were too many special enemies on screen already.");
                }
            }
            else
            {
                Instantiate(enemyPrefabs[enemyPrefabIndex], spawnPos, enemyPrefabs[enemyPrefabIndex].transform.rotation);
            }
        }
        yield return null;
    }

    IEnumerator SpawnEnemyLeft()
    {
        while (!dialogueManager.IsDialogueOver)
        {
            yield return null;
        }
        while (!playerCollisionManager.GameOver)
        {
            enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(spawnRangeZNega, spawnRangeZPosi));
            Instantiate(enemyPrefabs[enemyPrefabIndex], spawnPos, Quaternion.Euler(0, 270, 0));
        }
        yield return null;
    }

    IEnumerator SpawnEnemyRight()
    {
        while (!dialogueManager.IsDialogueOver)
        {
            yield return null;
        }
        while (!playerCollisionManager.GameOver)
        {
            enemyPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            float waitTime = Random.Range(minRepeatTime, maxRepeatTime);
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(spawnRangeZNega, spawnRangeZPosi));
            Instantiate(enemyPrefabs[enemyPrefabIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        }
        yield return null;
    }
}
