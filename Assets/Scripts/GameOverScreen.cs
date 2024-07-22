using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public AudioSource musicControler;
    public GameObject dataDisplay;
    [SerializeField] TextMeshProUGUI highScoreTextOriginal;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI scoreTextOriginal;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeTextOriginal;
    [SerializeField] TextMeshProUGUI timeText;

    public void Setup ()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        dataDisplay.SetActive(false);
        musicControler.Pause();
        highScoreText.text = highScoreTextOriginal.text;
        scoreText.text = scoreTextOriginal.text;
        timeText.text = timeTextOriginal.text;
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
