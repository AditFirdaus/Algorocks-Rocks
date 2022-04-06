using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpWeapon : MonoBehaviour, IPickable
{
    public AudioClip pickSound { get; set; } = null;
    public WeaponData[] weaponDatas;
    public void Pick(PickModule pickModule)
    {
        // Load random weapon
        WeaponData weaponData = weaponDatas[Random.Range(0, weaponDatas.Length)];

        GunManager gunManager = pickModule.GetComponentInChildren<GunManager>();

        gunManager.Load(weaponData);

        Destroy(gameObject);
    }
}
