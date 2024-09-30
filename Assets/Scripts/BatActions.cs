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
    public CameraBoundaries cameraBoundaries;
    public ScoreManager scoreManager;
    public GameManager gameManager;
    public GameObject jumpBlock;
    public TutorialMenu tutorialMenu;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("UserSeenTheTutorial", 0) == 0)
        {
            Time.timeScale = 0;
            joystick.gameObject.SetActive(false);
            tutorialMenu.ShowTutorialMenu();
        }
    }

    private void TeleportPlayer()
    {
        Vector3 clonePosition = clonePreview.transform.position;

        clonePosition.x = Mathf.Clamp(clonePosition.x, cameraBoundaries.leftBoundary, cameraBoundaries.rightBoundary);
        clonePosition.y = Mathf.Clamp(clonePosition.y, cameraBoundaries.botBoundary, cameraBoundaries.topBoundary);

        transform.position = clonePosition;
        audioManager.Move();
    }

    private void HideJumpBlock()
    {
        jumpBlock.SetActive(false);
        isMovingAllowed = true;
    }

    void Update()
    {
        if (tutorialMenu.isTutorialMenuHided && !gameOverSrcreen.isActiveAndEnabled)
        {
            Time.timeScale = 1;
            joystick.gameObject.SetActive(true);
        }

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        Camera.main.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if ((isMovingAllowed || timer.inBulletTime) && joystick.isTouching)
        {
            timer.inBulletTime = true;
            isMovingAllowed = false;
            arrow.SetActive(true);
            Time.timeScale = 0.05f;

            animator.SetBool("inBulletTime", true);

            Vector2 point = joystick.Direction.normalized;
            float angleRad = Mathf.Atan2(point.y, point.x);
            float angleDeg = angleRad * Mathf.Rad2Deg;

            arrow.transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        }
        else if (timer.inBulletTime && !joystick.isTouching)
        {
            TeleportPlayer();

            animator.SetBool("inBulletTime", false);
            timer.inBulletTime = false;
            arrow.SetActive(false);
            Time.timeScale = 1f;

            jumpBlock.SetActive(true);
            Invoke("HideJumpBlock", 0.85f);
        }
    }

    private void MonsterCollision()
    {
        isMovingAllowed = false;
        timer.inBulletTime = false;
        audioManager.Dead();
        gameOverSrcreen.Setup();
        joystick.gameObject.SetActive(false);
    }

    private void UpdateHighScore()
    {
        Debug.Log(scoreManager.totalScore);
        Debug.Log(gameManager.highScore);
        if (scoreManager.totalScore > gameManager.highScore)
        {
            gameManager.saveNewHighScore(scoreManager.totalScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Monster"))
        {
            MonsterCollision();
            UpdateHighScore();
        }
    }
}
