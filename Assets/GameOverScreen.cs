using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup ()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
