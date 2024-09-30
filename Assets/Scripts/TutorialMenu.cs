using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public bool isTutorialMenuHided = false;

    public void ShowTutorialMenu()
    {
        isTutorialMenuHided = false;
        gameObject.SetActive(true);
    }

    public void HideTutorialMenu()
    {
        isTutorialMenuHided = true;
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("UserSeenTheTutorial", 1);
    }
}
