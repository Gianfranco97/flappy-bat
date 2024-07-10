using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public AudioSource musicControler;

    public void Setup ()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        musicControler.Pause();
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
