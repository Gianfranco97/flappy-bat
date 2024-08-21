using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject prefab;
    [SerializeField] float interval = 3f;
    public LayerMask collisionLayerMask;

    private bool IsPositionValid(Vector2 position)
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(collisionLayerMask);
        contactFilter.useTriggers = true;

        Collider2D[] results = new Collider2D[1];
        int count = Physics2D.OverlapCircle(position, 0.5f, contactFilter, results);

        return count == 0;
    }

    private void GenerateObject()
    {
        float objectPositionX = Camera.main.transform.position.x + 5;
        float objectPositionY = Random.Range(-4.5f, 4.5f);

        if (IsPositionValid(new Vector2(objectPositionX, objectPositionY)))
        {
            GameObject newGameObject = Instantiate(prefab, new Vector3(objectPositionX, objectPositionY, 0), Quaternion.identity);
            newGameObject.transform.SetParent(transform);
        };
    }

    private void GenerateObjectWithCleaner()
    {
        GenerateObject();
    }

    private void Start()
    {
        GenerateObject();
        InvokeRepeating("GenerateObjectWithCleaner", 5f, interval);
    }
}
