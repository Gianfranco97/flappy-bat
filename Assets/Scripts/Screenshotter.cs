using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    int count = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("C:\\Users\\gianf\\Desktop\\Capturas de pantalla FlappyBat\\Screenshot" + count + ".png");
            count++;
        }
    }
}
