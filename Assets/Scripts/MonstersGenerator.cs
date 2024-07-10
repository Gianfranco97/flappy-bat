using UnityEngine;
using UnityEngine.UI;

public class MonstersGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject prefabFlyingEye;
    [SerializeField] GameObject prefabFlyingSentinel;
    [SerializeField] GameObject prefabGhost;
    [SerializeField] GameObject prefabSuperBat;
    [SerializeField] float interval = 3f;
    public Image nextMonsterImage;
    public LayerMask collisionLayerMask;
    private int nextMonster = 0;

    private bool IsPositionValid(Vector2 position)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(collisionLayerMask);
        contactFilter.useTriggers = true;

        Collider2D[] results = new Collider2D[1];
        int count = Physics2D.OverlapCircle(position, 0.5f, contactFilter, results);

        return count == 0;
    }

    private GameObject InstantiateMonster(GameObject prefab, float objectPositionX, float objectPositionY)
    {
        GameObject newGameObject = Instantiate(prefab, new Vector3(objectPositionX, objectPositionY, 0), Quaternion.identity);
        newGameObject.transform.SetParent(transform);

        return newGameObject;
    }

    private void GenerateFlyingSentinel()
    {
        float objectPositionX = Camera.main.transform.position.x + 5;
        float objectPositionY = player.position.y;

        if (IsPositionValid(new Vector2(objectPositionX, objectPositionY)))
        {
            InstantiateMonster(prefabFlyingSentinel, objectPositionX, objectPositionY);
        };
    }

    private void GenerateFlyingEye()
    {
        bool goingUp = Random.Range(0, 2) == 0;
        float objectPositionX = Camera.main.transform.position.x + Random.Range(4, 7);
        float objectPositionY = goingUp ? -6 : 6;

        if (IsPositionValid(new Vector2(objectPositionX, objectPositionY)))
        {
            GameObject monster = InstantiateMonster(prefabFlyingEye, objectPositionX, objectPositionY);
            monster.GetComponent<Rigidbody2D>().gravityScale = goingUp ? -1 : 1;
        };
    }

    private void GenerateSuperBat()
    {
        float objectPositionX = Camera.main.transform.position.x - 7;
        float objectPositionY = player.position.y;

        if (IsPositionValid(new Vector2(objectPositionX, objectPositionY)))
        {
            GameObject monster = InstantiateMonster(prefabSuperBat, objectPositionX, objectPositionY);
            monster.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
        };
    }

    private void GenerateGhost()
    {
        float objectPositionX = Camera.main.transform.position.x - 2f;
        float objectPositionY = 6;

        if (IsPositionValid(new Vector2(objectPositionX, objectPositionY)))
        {
            InstantiateMonster(prefabGhost, objectPositionX, objectPositionY);
        };
    }

    private void SelectNextMonster()
    {
        nextMonster = Random.Range(0, 4);

        switch (nextMonster)
        {
            case 0:
                nextMonsterImage.sprite = prefabFlyingSentinel.GetComponent<SpriteRenderer>().sprite;
                break;
            case 1:
                nextMonsterImage.sprite = prefabFlyingEye.GetComponent<SpriteRenderer>().sprite;
                break;
            case 2:
                nextMonsterImage.sprite = prefabGhost.GetComponent<SpriteRenderer>().sprite;
                break;
            case 3:
                nextMonsterImage.sprite = prefabSuperBat.GetComponent<SpriteRenderer>().sprite;
                break;
        }
    }

    private void GenerateMonster()
    {
        switch (nextMonster)
        {
            case 0:
                GenerateFlyingSentinel();
                break;
            case 1:
                GenerateFlyingEye();
                break;
            case 2:
                GenerateGhost();
                break;
            case 3:
                GenerateSuperBat();
                break;
        }

        SelectNextMonster();
    }

    private void Start()
    {
        InvokeRepeating("GenerateMonster", 1f, interval);
    }
}
