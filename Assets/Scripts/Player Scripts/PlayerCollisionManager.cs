using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionManager : MonoBehaviour
{
    private float Health;
    private PlayerController playerController;
    private LaunchProjectile Launcher;
    private RotateTurret rotateTurret;
    [SerializeField] GameObject enemySpawner;
    private EnemySpawnManager enemySpawnerScript;
    [SerializeField] GameObject medkitSpawner;
    private MedkitSpawnManager medkitSpawnerScript;
    [SerializeField] GameObject healthDisplay;
    private Text healthText;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject finalScoreDisplay;
    private FinalScoreDisplay finalScoreDisplayer;
    [SerializeField] GameObject deathSmoke;
    [SerializeField] GameObject explosion;
    private AudioSource hitSound;
    private bool gameOver;
    private AudioSource lowHealthNoise;
    private AudioSource repairNoise;
    [SerializeField] GameObject damageSmoke;
    [SerializeField] GameObject fire;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float healthDecrementer = 10;
    [SerializeField] float hiHealth = 80;
    [SerializeField] float loHealth = 50;
    [SerializeField] float minHealth = 0;
    [SerializeField] Color32 hiHealthColor = new Color32(0, 255, 52, 255);
    [SerializeField] Color32 medHealthColor = new Color32(255, 227, 0, 255);
    [SerializeField] Color32 loHealthColor = new Color32(255, 10, 0, 255);
    [SerializeField] Material greenTankMaterial;
    [SerializeField] Material yellowTankMaterial;
    [SerializeField] float powerupTimer = 8;
    [SerializeField] GameObject tankParent;
    private AudioSource engineNoise;
    [SerializeField] GameObject levelClearScreen;
    [SerializeField] GameObject finalTimeDisplay;
    private FinalTimeDisplay finalTimeDisplayer;
    private GameObject totalsTrackerObject;
    private TotalsTracker totalsTracker;
    private MeshRenderer meshRenderer;
    [SerializeField] GameObject turret;
    private MeshRenderer turretMeshRenderer;
    [SerializeField] GameObject musicManagerObject;
    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        enemySpawnerScript = enemySpawner.GetComponent<EnemySpawnManager>();
        Launcher = GetComponentInChildren<LaunchProjectile>();
        rotateTurret = GetComponentInChildren<RotateTurret>();
        medkitSpawnerScript = medkitSpawner.GetComponent<MedkitSpawnManager>();
        healthText = healthDisplay.GetComponent<Text>();
        Health = maxHealth;
        healthText.text = $"Structural Integrity: {Health}%";
        finalScoreDisplayer = finalScoreDisplay.GetComponent<FinalScoreDisplay>();
        finalTimeDisplayer = finalTimeDisplay.GetComponent<FinalTimeDisplay>();
        hitSound = GetComponent<AudioSource>();
        gameOver = false;
        lowHealthNoise = healthDisplay.GetComponent<AudioSource>();
        repairNoise = medkitSpawner.GetComponent<AudioSource>();
        engineNoise = tankParent.GetComponent<AudioSource>();
        totalsTrackerObject = GameObject.FindGameObjectWithTag("TotalsTracker");
        totalsTracker = totalsTrackerObject.GetComponent<TotalsTracker>();
        meshRenderer = GetComponent<MeshRenderer>();
        turretMeshRenderer = turret.GetComponent<MeshRenderer>();
        MakeTankGreen();
        musicManager = musicManagerObject.GetComponent<MusicManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            if (!gameOver && Health > minHealth)
            {
                Health -= healthDecrementer;
                totalsTracker.TotalDamage += healthDecrementer;
                hitSound.Play();
            }
            else
            {
                Health = minHealth;
            }
            healthText.text = $"Structural Integrity: {Health}%";
            if(!gameOver && Health <= minHealth)
            {
                StopEverything();
                KillPlayer();
            }
        }
        if(collision.gameObject.CompareTag("Medkit"))
        {
            Destroy(collision.gameObject);
            if(Health < maxHealth)
            {
                if (!gameOver)
                {
                    repairNoise.Play();
                }
            }
            Health += maxHealth;
            if (Health >= maxHealth)
            {
                Health = maxHealth;
            }
            healthText.text = $"Structural Integrity: {Health}%";
        }
        if(collision.gameObject.CompareTag("Powerup"))
        {
            if (!gameOver)
            {
                repairNoise.Play();
                Destroy(collision.gameObject);
                StartCoroutine("Powerup");
                playerController.StartCoroutine("Powerup");
                Launcher.StartCoroutine("Powerup");
            }
            else
            {
                Destroy(collision.gameObject);
            }
            
        }
        if (Health > hiHealth)
        {
            healthText.color = hiHealthColor;
            lowHealthNoise.enabled = false;
            damageSmoke.SetActive(false);
            fire.SetActive(false);
        }
        else if (Health > loHealth)
        {
            healthText.color = medHealthColor;
            lowHealthNoise.enabled = false;
            damageSmoke.SetActive(true);
            fire.SetActive(false);
        }
        else if (!gameOver)
        {
            healthText.color = loHealthColor;
            lowHealthNoise.enabled = true;
            damageSmoke.SetActive(false);
            fire.SetActive(true);
        }
    }

    IEnumerator Powerup()
    {
        MakeTankYellow();
        musicManager.SetPowerupMusic();
        yield return new WaitForSeconds(powerupTimer);
        MakeTankGreen();
        musicManager.SetLevelMusic();
        yield return null;
    }

    internal void StopEverything()
    {
        gameOver = true;
        playerController.enabled = false;
        Launcher.enabled = false;
        rotateTurret.enabled = false;
        fire.SetActive(false);
        StopAllCoroutines();
        MakeTankGreen();
        medkitSpawnerScript.StopAllCoroutines();
        medkitSpawner.SetActive(false);
        enemySpawnerScript.StopAllCoroutines();
        enemySpawner.SetActive(false);
        damageSmoke.SetActive(false);
        engineNoise.enabled = false;
        HUD.SetActive(false);
        musicManager.StopMusic();
    }

    private void KillPlayer()
    {
        Health = minHealth;
        explosion.SetActive(true);
        deathSmoke.SetActive(true);
        gameOverScreen.SetActive(true);
        finalScoreDisplayer.Invoke("ShowFinalScore", 0);
    }

    internal void LevelClear()
    {
        levelClearScreen.SetActive(true);
        finalTimeDisplayer.Invoke("ShowFinalTime", 0);
    }

    internal bool GameOver { get { return gameOver; } }

    private void MakeTankGreen()
    {
        meshRenderer.material = greenTankMaterial;
        turretMeshRenderer.material = greenTankMaterial;
    }
    private void MakeTankYellow()
    {
        meshRenderer.material = yellowTankMaterial;
        turretMeshRenderer.material = yellowTankMaterial;
    }
}
