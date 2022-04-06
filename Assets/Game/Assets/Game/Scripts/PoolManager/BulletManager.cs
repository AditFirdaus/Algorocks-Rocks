using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour, IPoolable<GameObject>
{
    public static BulletManager instance;
    public string poolKey = "bullet";
    public GameObject prefab;
    public int size = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            CreatePool();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreatePool()
    {
        PoolManager.AddPool(poolKey, this);
    }

    public GameObject PoolCreate()
    {
        GameObject obj = GameObject.Instantiate(prefab, transform);
        obj.SetActive(false);
        return obj;
    }

    public void PoolGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void PoolRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void PoolDestroy(GameObject obj)
    {
        GameObject.Destroy(obj);
    }
}
