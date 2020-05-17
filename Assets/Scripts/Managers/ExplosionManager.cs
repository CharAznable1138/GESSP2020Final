using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        Destroy(gameObject, particles.main.duration);
    }
}
