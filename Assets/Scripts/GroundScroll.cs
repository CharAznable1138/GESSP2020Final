using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float speed = 30;
    private PlayerCollisionManager playerCollisionManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerCollisionManagerScript = player.GetComponentInChildren<PlayerCollisionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerCollisionManagerScript.gameOver)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
