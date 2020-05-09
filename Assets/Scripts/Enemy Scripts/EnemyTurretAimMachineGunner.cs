using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretAimMachineGunner : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] float lowerBound = 1;
    private EnemyMachineGunnerLaunchProjectile bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("PlayerTurret");
        bulletSpawner = GetComponentInChildren<EnemyMachineGunnerLaunchProjectile>();
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
