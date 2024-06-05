using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]
    private float parallaxSpeed = 0.02f;

    private Transform cameraTransform;
    private float startPostionX;
    private float spriteSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        startPostionX = transform.position.x;
        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float distX = (cameraTransform.position.x * parallaxSpeed);
        transform.position = new Vector3(startPostionX + distX, transform.position.y, transform.position.z);

        float relativeX = (cameraTransform.position.x * (1 - parallaxSpeed));
        if (relativeX > startPostionX + spriteSizeX)
        {
            startPostionX += spriteSizeX;
        }
        else if (relativeX < startPostionX - spriteSizeX)
        {
            startPostionX -= spriteSizeX;
        }
    }
}
