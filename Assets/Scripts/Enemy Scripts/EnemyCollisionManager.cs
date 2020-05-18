using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    private MoveForward moveForward;
    private EnemyLaunchProjectile enemyLaunchProjectile;
    [SerializeField] GameObject chassis;
    private AudioSource hitSound;
    private EnemyTurretAim enemyTurretAim;
    private BoxCollider boxCollider;
    private bool isAlreadyHit;
    private GameObject scoreDisplay;
    private ScoreManager scoreManager;
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    private void Start()
    {
        moveForward = GetComponent<MoveForward>();
        enemyLaunchProjectile = GetComponentInChildren<EnemyLaunchProjectile>();
        hitSound = chassis.GetComponent<AudioSource>();
        enemyTurretAim = GetComponentInChildren<EnemyTurretAim>();
        boxCollider = GetComponent<BoxCollider>();
        isAlreadyHit = false;
        scoreDisplay = GameObject.Find("Score Display");
        scoreManager = scoreDisplay.GetComponent<ScoreManager>();
        totalsTrackerObject = GameObject.FindGameObjectWithTag("TotalsTracker");
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerProjectile"))
        {
            if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("EnemySpecial"))
            {
                Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
                Destroy(other.gameObject);
                scoreManager.ChangeScore(-1);
                totalsTracker.ShotsHit++;
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("EnemyTutorial"))
            {
                Destroy(other.gameObject);
                moveForward.Speed *= -1;
                enemyLaunchProjectile.StopAllCoroutines();
                hitSound.Play();
                enemyTurretAim.enabled = false;
                boxCollider.enabled = false;
                if(!isAlreadyHit)
                {
                    scoreManager.ChangeScore(-1);
                    totalsTracker.ShotsHit++;
                    isAlreadyHit = true;
                }
            }
        }
    }
}
