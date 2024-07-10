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
    }

    private void Update()
    {
        time += Time.deltaTime;
        scoreManager.AddScorePoints(1 * Time.deltaTime, false);
        text.text = "Time: " + time.ToString("F0") +"s";
        animator.SetBool("inBulletTime", inBulletTime);
    }
}
