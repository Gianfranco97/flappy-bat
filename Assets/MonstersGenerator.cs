using System.Collections;
using System.Linq;
using UnityEngine;

public class MonstersGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] monsters;
    public Transform player;
    public GameObject monsterPrefab;

    private void GenerateMonster()
    {
        monsters.Append(Instantiate(monsterPrefab, new Vector3(Camera.main.transform.position.x + 5, player.position.y, 0), Quaternion.identity));
    }

    private IEnumerator GenerateMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            GenerateMonster();
        }
    }

    private void Start()
    {
        GenerateMonster();
        StartCoroutine(GenerateMonsters());
    }
}
