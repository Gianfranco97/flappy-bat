using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] float totalScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI extraPointsText;

    private void HideExtraPoints()
    {
        extraPointsText.gameObject.SetActive(false);
    }

    public void AddScorePoints(float points, bool showFeedback)
    {
        totalScore += points;
        if (showFeedback)
        {
            extraPointsText.text = "+" + points.ToString("F0");
            extraPointsText.gameObject.SetActive(true);

            Invoke("HideExtraPoints", 1f);
        }
    }

    void Update()
    {
        scoreText.text = "Score: " + totalScore.ToString("F0");
    }
}
