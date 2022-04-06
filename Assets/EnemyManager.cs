using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>();
    public static EnemyManager instance;
    public EnemyData[] enemyDatas;
    public UnityEvent onEnemyClear;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        enemies = new List<Enemy>();
        CreateEnemy();
    }

    public static void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        CheckClear();
    }

    public static void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public static void CheckClear()
    {
        if (enemies.Count == 0)
        {
            instance.onEnemyClear.Invoke();
        }
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < enemyDatas.Length; i++)
        {

            int amount = enemyDatas[i].spawnAmount * Game.difficulty;

            for (int j = 0; j < amount; j++)
            {
                Vector2 size = BoundManager.instance.size / 3;

                Vector2 position = new Vector2(Random.Range(-size.x, size.x), Random.Range(-size.y, size.y));

                GameObject obj = Instantiate(enemyDatas[i].prefab, position, Quaternion.identity, transform);
            }
        }
    }

    public GameObject Create(EnemyData enemyData, Vector2 position)
    {
        GameObject obj = Instantiate(enemyData.prefab);

        obj.transform.position = position;

        return obj;
    }
}

[System.Serializable]
public class EnemyData
{
    public GameObject prefab;
    public int spawnAmount = 1;
}
