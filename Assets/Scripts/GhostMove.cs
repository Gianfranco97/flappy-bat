using UnityEngine;

public class GhostMove : MonoBehaviour
{
    private Rigidbody2D ghostBody;
    private SpriteRenderer ghostSprite;
    private bool GoingRight = false;
    [SerializeField] private float interval = 1;

    void ChangeDirection()
    {
        GoingRight = !GoingRight;
        ghostBody.velocity = new Vector2(GoingRight ? 9 : 1, 0);
        ghostSprite.flipX = GoingRight;
    }

    void Start()
    {
        ghostBody = GetComponent<Rigidbody2D>();
        ghostSprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("ChangeDirection", 0, interval);
    }
}
