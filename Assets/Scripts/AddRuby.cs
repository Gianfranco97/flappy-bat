using UnityEngine;

public class AddRuby : MonoBehaviour
{
    private AudioManager audioManager;
    private GameManager gameManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            audioManager.GetRuby();
            gameManager.ChangeRubiesQuantity(1);
            Destroy(gameObject);
        }
    }
}
