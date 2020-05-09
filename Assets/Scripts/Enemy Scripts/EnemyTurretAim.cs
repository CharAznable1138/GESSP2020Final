using UnityEngine;
//Credit to this thread for telling me about the LookAt() function: https://answers.unity.com/questions/661639/how-can-i-make-a-game-object-look-at-another-objec.html

public class EnemyTurretAim : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] float lowerBound = 1;
    private EnemyLaunchProjectile bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("PlayerTurret");
        bulletSpawner = GetComponentInChildren <EnemyLaunchProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > lowerBound)
        {
            gameObject.transform.LookAt(playerObject.transform);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            bulletSpawner.StopAllCoroutines();
        }
    }


}
