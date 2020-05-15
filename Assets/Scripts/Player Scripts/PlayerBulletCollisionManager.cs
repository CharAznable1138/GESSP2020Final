using UnityEngine;

public class PlayerBulletCollisionManager : MonoBehaviour
{
    private GameObject scoreDisplay;
    private ScoreManager scoreManager;
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("Score Display");
        scoreManager = scoreDisplay.GetComponent<ScoreManager>();
        totalsTrackerObject = GameObject.FindGameObjectWithTag("TotalsTracker");
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemySpecial"))
        {
            scoreManager.ChangeScore(-1);
            totalsTracker.ShotsHit++;
        }
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
