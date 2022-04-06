using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPHealth : MonoBehaviour, IPickable
{
    public int healthAmount = 50;
    public void Pick(PickModule pickModule)
    {
        HealthModule healthModule = pickModule.GetComponent<HealthModule>();

        if (healthModule)
        {
            healthModule.health += healthAmount;
        }

        Destroy(gameObject);
    }
}
