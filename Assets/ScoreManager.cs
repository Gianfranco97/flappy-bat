using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] float totalScore = 0; 
    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void AddScorePoints(float points)
    {
        totalScore += points;
    }

    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString("F0");
    }
}
