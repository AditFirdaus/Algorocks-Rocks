using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Dictionary<string, ObjectPool<GameObject>> poolDictionary = new Dictionary<string, ObjectPool<GameObject>>();

    public static void AddPool(string poolKey, IPoolable<GameObject> poolable, int size = 10)
    {
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(poolable.PoolCreate, poolable.PoolGet, poolable.PoolRelease, poolable.PoolDestroy, size);
        AddPool(poolKey, pool);
    }

    public static void AddPool(string poolKey, ObjectPool<GameObject> pool)
    {
        if (KeyValid(poolKey)) return;
        poolDictionary.Add(poolKey, pool);
    }

    public static GameObject Get(string poolKey)
    {
        return poolDictionary[poolKey].Get();
    }

    public static void Release(string poolKey, GameObject obj)
    {
        if (obj == null) return;
        poolDictionary[poolKey].Release(obj);
    }

    public static bool KeyValid(string poolKey) => poolDictionary.ContainsKey(poolKey);
}
