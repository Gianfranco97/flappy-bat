using UnityEngine;

public class AddExtraPoints : MonoBehaviour
{
    private ScoreManager scoreManager;
    private AudioManager audioManager;
    [SerializeField] float points = 100;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            scoreManager.AddScorePoints(points, true);
            audioManager.GetItem();
            Destroy(gameObject);
        }
    }
}
