using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public static EffectManager instance;

    public PoolEffect[] poolEffects;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    public void InitializePool()
    {
        foreach (PoolEffect poolEffect in poolEffects)
        {
            CreatePoolEffect(poolEffect);
        }
    }

    public void CreatePoolEffect(PoolEffect poolEffect)
    {
        PoolManager.AddPool(poolEffect.poolKey, poolEffect);
    }
}

[System.Serializable]
public class PoolEffect : IPoolable<GameObject>
{
    public Transform group;

    public string poolKey;
    public GameObject prefab;

    public void CreateGroup()
    {
        group = new GameObject(poolKey).transform;
        group.parent = EffectManager.instance.transform;
        GameObject.DontDestroyOnLoad(group.parent.gameObject);
    }

    public GameObject PoolCreate()
    {
        if (!group) CreateGroup();

        GameObject obj = GameObject.Instantiate(prefab, group);
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
