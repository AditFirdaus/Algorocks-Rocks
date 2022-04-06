using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public bool isFiring = false;
    public int gunLayer => gameObject.layer;
    public bool empty => ammo <= 0;
    public int ammo = 100;

    public WeaponData defaultData;
    public WeaponData weaponData;
    public Transform nozzle;

    public string shootEffect;
    public AudioSource audioSource;
    public AudioClip shootSound;

    Coroutine gunCoroutine;

    private void Start()
    {
        gunCoroutine = StartCoroutine(GunCoroutine());
    }

    public void Fire()
    {
        if (weaponData == null) weaponData = defaultData;

        bool use = weaponData.useAmmo;

        for (int i = 0; i < weaponData.shootAmount; i++)
        {
            if (use && empty) break;

            Vector2 position = nozzle.position;
            Vector3 euler = nozzle.eulerAngles;

            float OffsetWidth = weaponData.GetWidthOffset(i);
            float OffsetAngle = weaponData.GetAngleOffset(i);

            Vector2 offsetDirection = transform.TransformVector(OffsetWidth * (Vector2)Vector2.up);

            position += offsetDirection;
            euler.z += OffsetAngle;

            Bullet bullet = CreateBullet(position, euler);

            bullet.Deploy();

            if (use) ammo--;
        }

        if (use && empty) Load(defaultData);
    }

    public IEnumerator GunCoroutine()
    {
        while (true)
        {
            if (isFiring)
            {
                Fire();
                yield return new WaitForSeconds((1f / weaponData.shootRate * weaponData.shootRateMultiplyer));
            }
            yield return null;
        }
    }

    public Bullet CreateBullet(Vector3 position, Vector3 euler)
    {
        GameObject bulletEffectShoot = PoolManager.Get(shootEffect);

        if (bulletEffectShoot)
        {
            bulletEffectShoot.transform.position = position;
            bulletEffectShoot.transform.eulerAngles = euler;
        }

        audioSource.PlayOneShot(shootSound);

        GameObject obj = Bullet.Get();

        obj.transform.position = position;
        obj.transform.eulerAngles = euler;

        obj.layer = gunLayer;

        Bullet bullet = obj.GetComponent<Bullet>();

        BulletData bulletData = weaponData.gunEffect.ApplyEffect(bullet.bulletData);

        bullet._bulletData = bulletData;

        return bullet;
    }

    public void Load(WeaponData weapon)
    {
        weaponData = weapon;

        ammo = weapon.weaponAmmo;
    }
}



