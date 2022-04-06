using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponData
{
    public bool useAmmo = true;
    public float shootWidth = 2.5f;
    public float shootAngle = 0;
    public float shootRate = 10;
    public float shootRateMultiplyer = 1;
    public int shootAmount = 1;
    public int weaponAmmo = 100;
    public GunEffect gunEffect;

    public float GetWidthOffset(int index) => this.GetOffset(shootWidth, index);
    public float GetAngleOffset(int index) => this.GetOffset(shootAngle, index);
}

public static class GunDataUtillity
{

    public static float GetOffset(this WeaponData data, float size = 0, int index = 0)
    {
        if (data.shootAmount == 0) return 0;

        float half = size / 2;
        float perBullet = size / data.shootAmount;

        return (perBullet * index) + (perBullet / 2) - half;
    }
}
