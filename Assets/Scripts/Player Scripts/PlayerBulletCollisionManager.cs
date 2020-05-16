using UnityEngine;

public class PlayerBulletCollisionManager : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
