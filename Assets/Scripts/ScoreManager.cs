using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int totalScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI extraPointsText;

    private void HideExtraPoints()
    {
        extraPointsText.gameObject.SetActive(false);
    }

    public void AddScorePoints(int points, bool showFeedback)
    {
        totalScore += points;
        if (showFeedback)
        {
            extraPointsText.text = $"+{points}";
            extraPointsText.gameObject.SetActive(true);

            Invoke("HideExtraPoints", 1f);
        }
    }

    void Update()
    {
        scoreText.text = $"Actual Score: {totalScore}";
    }
}
