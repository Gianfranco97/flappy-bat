using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool connectedToGooglePlay;
    public int highScore;
    public int rubiesQuantity;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI[] rubiesTexts;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        rubiesQuantity = PlayerPrefs.GetInt("Rubies", 0);
        UpdateHighScoreText(highScore);
        ChangeRubiesQuantity(0);
    }


    private void UpdateHighScoreText(int newHighScore)
    {
        highScoreText.text = $"High Score: {newHighScore}";
    }

    public void saveNewHighScore(int newHighScore)
    {
        highScore = newHighScore;
        PlayerPrefs.SetInt("HighScore", newHighScore);
        UpdateHighScoreText(newHighScore);
    }

    public void ChangeRubiesQuantity(int rubies)
    {
        rubiesQuantity += rubies;
        PlayerPrefs.SetInt("Rubies", rubiesQuantity);
        string newRubiesText = $"{rubiesQuantity}x";
        foreach (TextMeshProUGUI rubiesText in rubiesTexts)
        {
            rubiesText.text = newRubiesText;
        }
    }
}
