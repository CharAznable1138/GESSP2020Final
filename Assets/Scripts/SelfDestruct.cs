using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float sdDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", sdDelay);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
