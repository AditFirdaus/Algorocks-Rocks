using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyStatus enemyStatus;
    public EnemyAI enemyAI;
    public HealthModule healthModule;
    public GunManager gunManager;
    public WeaponData weaponData;
    public string destroyEffect = "Effect_Explosion";
    public AudioSource audioSource;
    public AudioClip hitSound;
    public EnemyDrop[] enemyDrops;

    private void Start()
    {
        EnemyManager.AddEnemy(this);
        Load(enemyStatus);
    }

    public void Load(EnemyStatus status)
    {
        this.enemyStatus = status;
        healthModule.health = status.health;

        weaponData.gunEffect.damageMultiplyer = status.damage;
        weaponData.gunEffect.speedMultiplyer = status.bulletSpeed;
        weaponData.shootRateMultiplyer = status.attackRate;

        gunManager.defaultData = weaponData;
        gunManager.Load(weaponData);
    }

    public void Damage(float damage)
    {
        healthModule.health -= damage;
        audioSource.PlayOneShot(hitSound);
    }

    public void Defeat()
    {
        GameObject bulletEffectShoot = PoolManager.Get("Effect_Explosion");

        if (bulletEffectShoot)
        {
            bulletEffectShoot.transform.position = transform.position;
            bulletEffectShoot.transform.eulerAngles = transform.eulerAngles;
        }

        ScoreManager.score += enemyStatus.score;

        EnemyManager.RemoveEnemy(this);

        DropRandom();

        Destroy(gameObject);
    }

    public void DropRandom()
    {
        EnemyDrop drop = enemyDrops[Random.Range(0, enemyDrops.Length)];
        if (Random.value < drop.chance)
        {
            GameObject obj = Instantiate(drop.item, transform.position, Quaternion.identity);
        }
    }

}

[System.Serializable]
public class EnemyDrop
{
    public GameObject item;
    [Range(0, 1)] public float chance;
}
