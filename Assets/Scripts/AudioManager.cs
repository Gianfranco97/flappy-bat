using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuButton, getItem, getRuby, dead, move;

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

    public void GetRuby()
    {
        audioSource.clip = getRuby;
        audioSource.Play();
    }

    public void Move()
    {
        audioSource.clip = move;
        audioSource.Play();
    }
}
