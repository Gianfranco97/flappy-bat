using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float time = 0;
    public ScoreManager scoreManager;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        scoreManager.AddScorePoints(1 * Time.deltaTime);
        text.text = "Time: " + time.ToString("F0") +"s";
    }
}
