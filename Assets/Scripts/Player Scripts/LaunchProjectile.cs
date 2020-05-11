using System.Collections;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private AudioSource firingNoise;
    [SerializeField] float delay = 1;
    private bool coolDown;
    [SerializeField] GameObject cooldownDisplay;
    [SerializeField] float powerupDelayDecrementer = 0.5f;
    [SerializeField] float powerupTimer = 8;
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    // Start is called before the first frame update
    void Start()
    {
        firingNoise = GetComponent<AudioSource>();
        coolDown = false;
        cooldownDisplay.SetActive(false);
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && !coolDown) || (Input.GetKeyDown(KeyCode.Mouse0) && !coolDown))
        {
            firingNoise.Play();
            Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(bulletPrefab.transform.rotation.x, transform.rotation.y, bulletPrefab.transform.rotation.z, bulletPrefab.transform.rotation.w));
            StartCoroutine("Cooldown");
            totalsTracker.ShotsTaken++;
        }
    }

    IEnumerator Cooldown()
    {
        coolDown = true;
        cooldownDisplay.SetActive(true);
        yield return new WaitForSeconds(delay);
        coolDown = false;
        cooldownDisplay.SetActive(false);
        yield return null;
    }

    internal IEnumerator Powerup()
    {
        delay -= powerupDelayDecrementer;
        yield return new WaitForSeconds(powerupTimer);
        delay += powerupDelayDecrementer;
        yield return null;
    }
}
