using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public SpriteRenderer player;

    private float SizeX, SizeY;
    private float playerHeight, playerWidth;

    public float leftBoundary;
    public float rightBoundary;
    public float topBoundary;
    public float botBoundary;

    private void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        BoxCollider2D cameraBox = cam.GetComponent<BoxCollider2D>();
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        cameraBox.size = new Vector2(width, height);

        SizeY = cameraBox.size.y / 2;
        SizeX = cameraBox.size.x / 2;

        playerHeight = player.bounds.extents.y;
        playerWidth = player.bounds.extents.x;

        CalculateCameraBoundriesY();
    }

    void CalculateCameraBoundriesY()
    {
        botBoundary = transform.position.y - SizeY + playerHeight;
        topBoundary = transform.position.y + SizeY - playerHeight;
    }

    void CalculateCameraBoundriesX()
    {
        leftBoundary = transform.position.x - SizeX + playerWidth;
        rightBoundary = transform.position.x + SizeX - playerWidth;
    }

    void Update()
    {
        CalculateCameraBoundriesX();
    }
}
