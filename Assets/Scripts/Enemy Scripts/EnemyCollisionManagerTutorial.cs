using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionManagerTutorial : MonoBehaviour
{
    private MoveForward moveForward;
    private EnemyLaunchProjectile enemyLaunchProjectile;
    [SerializeField] GameObject chassis;
    private AudioSource hitSound;
    private EnemyTurretAim enemyTurretAim;
    private void Start()
    {
        moveForward = GetComponent<MoveForward>();
        enemyLaunchProjectile = GetComponentInChildren<EnemyLaunchProjectile>();
        hitSound = chassis.GetComponent<AudioSource>();
        enemyTurretAim = GetComponentInChildren<EnemyTurretAim>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(other.gameObject);
            moveForward.Speed *= -1;
            enemyLaunchProjectile.StopAllCoroutines();
            hitSound.Play();
            enemyTurretAim.enabled = false;
        }
    }
}
