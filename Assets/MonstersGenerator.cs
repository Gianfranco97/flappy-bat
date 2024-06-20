using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonstersGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> monsters;
    public Transform player;
    public GameObject monsterPrefab;

    private void GenerateMonster()
    {
        monsters.Add(Instantiate(monsterPrefab, new Vector3(Camera.main.transform.position.x + 5, player.position.y, 0), Quaternion.identity));
    }

    private void GenerateMonsterWithCleaner()
    {
        GenerateMonster();
        Destroy(monsters.First());
        monsters.RemoveAt(0);
    }

    private void Start()
    {
        GenerateMonster();
        InvokeRepeating("GenerateMonsterWithCleaner", 3f, 3f);
    }
}
