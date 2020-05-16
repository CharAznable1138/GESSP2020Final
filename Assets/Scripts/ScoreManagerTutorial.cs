using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerTutorial : MonoBehaviour
{
    [SerializeField] int starterScore;
    private int score;
    private Text scoreText;
    [SerializeField] GameObject player;
    private PlayerCollisionManager playerCollisionManager;

    // Start is called before the first frame update
    void Start()
    {
        score = starterScore;
        scoreText = GetComponent<Text>();
        scoreText.text = $"\"Enemies\"\nRemaining: {score}";
        playerCollisionManager = player.GetComponentInChildren<PlayerCollisionManager>();
    }

    internal void ChangeScore(int _arg)
    {
        score += _arg;
        scoreText.text = $"\"Enemies\"\nRemaining: {score}";
        if (score <= 0)
        {
            playerCollisionManager.StopEverything();
            playerCollisionManager.LevelClear();
        }
    }

    internal int Score { get { return score; } }
}
