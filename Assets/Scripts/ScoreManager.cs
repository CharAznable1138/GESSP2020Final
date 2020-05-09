using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int starterScore;
    private int score;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = starterScore;
        scoreText = GetComponent<Text>();
        scoreText.text = $"Enemies\nRemaining: {score}";
    }

    internal void ChangeScore(int _arg)
    {
        score += _arg;
        scoreText.text = $"Enemies\nRemaining: {score}";
    }

    internal int Score { get { return score; } }
}
