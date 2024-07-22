using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public ScoreManager scoreManager;
    public bool inBulletTime = false;
    private float time = 0;
    private TextMeshProUGUI text;
    private Animator animator;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        InvokeRepeating("IncreaseScore", 0, 1f);
    }

    private void IncreaseScore()
    {
        time += 1;
        scoreManager.AddScorePoints(1, false);
        text.text = "Time: " + time.ToString("F0") + "s";
    }

    private void Update()
    {
        animator.SetBool("inBulletTime", inBulletTime);
    }
}
