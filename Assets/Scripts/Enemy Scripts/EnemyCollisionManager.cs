using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerProjectile"))
        {
            Instantiate(explosion, gameObject.transform.position, explosion.transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
