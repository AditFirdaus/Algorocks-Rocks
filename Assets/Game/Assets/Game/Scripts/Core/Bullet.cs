using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static string poolKey = "bullet";
    public BulletData bulletData;
    public BulletData _bulletData;

    public Rigidbody2D rb;
    public string hitEffect;

    float deployTime;
    public float currentLifetime => Time.time - deployTime;

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
        damagable?.Damage(_bulletData.damage);

        Release();
    }

    private void Update()
    {
        if (currentLifetime > _bulletData.lifetime)
        {
            Release();
        }
    }

    public void Deploy()
    {
        deployTime = Time.time;
        rb.velocity = transform.right * _bulletData.speed;
    }

    public static GameObject Get()
    {
        if (!PoolManager.KeyValid(poolKey)) PoolManager.AddPool(poolKey, BulletManager.instance);

        return PoolManager.Get(poolKey);
    }
    public void Release()
    {
        GameObject bulletEffectShoot = PoolManager.Get(hitEffect);

        if (bulletEffectShoot)
        {
            bulletEffectShoot.transform.position = transform.position;
            bulletEffectShoot.transform.eulerAngles = transform.eulerAngles;
        }

        PoolManager.Release(poolKey, gameObject);
    }
}


[System.Serializable]
public struct BulletData
{
    public float damage;
    public float speed;
    public float lifetime;

    public BulletData(float damage = 1, float speed = 1, float lifetime = 1)
    {
        this.damage = damage;
        this.speed = speed;
        this.lifetime = lifetime;
    }
}
