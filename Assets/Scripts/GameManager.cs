using GooglePlayGames;
using GooglePlayGames.BasicApi;
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
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        rubiesQuantity = PlayerPrefs.GetInt("Rubies", 0);
        UpdateHighScoreText(highScore);
        ChangeRubiesQuantity(0);
    }

    void Start()
    {
        LogInToGooglePlay();
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

        if (!connectedToGooglePlay) LogInToGooglePlay();
        Social.ReportScore(newHighScore, GPGSIds.leaderboard_score, LeaderboardUpdate);
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

    private void LogInToGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status)
    {
        connectedToGooglePlay = status == SignInStatus.Success;
    }

    public void showLeaderBoard()
    {
        if (!connectedToGooglePlay) LogInToGooglePlay();
        Social.ShowLeaderboardUI();
    }

    private void LeaderboardUpdate(bool success)
    {
        if (success) Debug.Log("Updated Leaderboard");
        else Debug.Log("Unable to update Leaderborad");
    }
}
