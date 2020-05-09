using UnityEngine;

public class PlayerBulletCollisionManager : MonoBehaviour
{
    private GameObject scoreDisplay;
    private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay");
        scoreManager = scoreDisplay.GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            scoreManager.ChangeScore(-1);
        }
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
