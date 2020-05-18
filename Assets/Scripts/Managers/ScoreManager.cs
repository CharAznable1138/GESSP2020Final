using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int starterScore;
    private int score;
    private Text scoreText;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;
    private int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        score = starterScore;
        scoreText = GetComponent<Text>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (currentSceneIndex)
        {
            case (1):
                scoreText.text = $"\"Enemies\"\nRemaining: {score}";
                break;
            default:
                scoreText.text = $"Enemies\nRemaining: {score}";
                break;
        }
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
    }

    internal void ChangeScore(int _arg)
    {
        score += _arg;
        switch (currentSceneIndex)
        {
            case (1):
                scoreText.text = $"\"Enemies\"\nRemaining: {score}";
                break;
            default:
                scoreText.text = $"Enemies\nRemaining: {score}";
                break;
        }
        if (score <= 0)
        {
            playerCollisionManager.StopEverything();
            playerCollisionManager.LevelClear();
        }
    }

    internal int Score { get { return score; } }
}
