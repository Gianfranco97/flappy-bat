using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuButton, getItem, dead, move;

    public void ClickMenuButton()
    {
        audioSource.clip = menuButton;
        audioSource.Play();
    }

    public void Dead() {
        audioSource.clip = dead; 
        audioSource.Play();
    }

    public void GetItem()
    {
        audioSource.clip = getItem;
        audioSource.Play();
    }

    public void Move()
    {
        audioSource.clip = move;
        audioSource.Play();
    }
}
