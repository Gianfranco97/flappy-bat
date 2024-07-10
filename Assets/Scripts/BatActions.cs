using System.Threading.Tasks;
using UnityEngine;


public class BatActions : MonoBehaviour
{
    public Joystick joystick;
    public GameObject arrow;
    public GameObject clonePreview;
    public GameObject orinalPlayer;
    public bool FacingRight = true;
    public bool isMovingAllowed = true;
    public float moveSpeed = 5f;
    public GameOverScreen gameOverSrcreen;
    public Animator animator;
    public int moveTime = 500;
    public Timer timer;
    public AudioManager audioManager;
    private float objectWidth;
    private float objectHeight;


    void Start()
    {
        objectWidth = orinalPlayer.transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = orinalPlayer.transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    private void TeleportPlayer()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 clonePosition = clonePreview.transform.position;

        clonePosition.x = Mathf.Clamp(clonePosition.x, screenBounds.x - Camera.main.orthographicSize - objectWidth, screenBounds.x - objectWidth);
        clonePosition.y = Mathf.Clamp(clonePosition.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        transform.position = clonePosition;
        audioManager.Move();
    }

    private async void showDirectionArrow()
    {
        if (timer.inBulletTime == false && isMovingAllowed)
        {
            isMovingAllowed = false;
            arrow.SetActive(true);
            Time.timeScale = 0.05f;

            animator.SetBool("inBulletTime", true);
            timer.inBulletTime = true;

            await Task.Delay(moveTime);

            animator.SetBool("inBulletTime", false);
            timer.inBulletTime = false;

            TeleportPlayer();
            arrow.SetActive(false);
            Time.timeScale = 1f;
        }

    }

    private void DirectionalArrow()
    {
        showDirectionArrow();

        float directionX = joystick.Direction.x;
        float directionY = joystick.Direction.y;
        float degrees = directionX + directionY * 360;

        arrow.transform.rotation = Quaternion.Euler(0, 0, degrees);
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        Camera.main.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (joystick.isTouching)
        {
            DirectionalArrow();
        }
        else if (!joystick.isTouching)
        {
            isMovingAllowed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Monster"))
        {
            audioManager.Dead();
            gameOverSrcreen.Setup();
            joystick.gameObject.SetActive(false);
        }
    }
}
