using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretAimTripleShooter : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] float lowerBound = 1;
    private EnemyTripleShooterLaunchProjectile bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("PlayerTurret");
        bulletSpawner = GetComponentInChildren<EnemyTripleShooterLaunchProjectile>();
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
