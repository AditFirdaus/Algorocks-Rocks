using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunEffect
{
    public float damageMultiplyer = 1;
    public float speedMultiplyer = 1;

    public BulletData ApplyEffect(BulletData bulletData)
    {

        bulletData.damage *= damageMultiplyer;
        bulletData.speed *= speedMultiplyer;

        return bulletData;
    }
}
