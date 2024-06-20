using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float time = 0;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        text.text = "Time: " + time.ToString("F0") +"s";
    }
}
