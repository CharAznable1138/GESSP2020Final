using UnityEngine;

public class PlayerBulletCollisionManager : MonoBehaviour
{
    [SerializeField] GameObject bulletCollisionNoise;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Instantiate(bulletCollisionNoise, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
