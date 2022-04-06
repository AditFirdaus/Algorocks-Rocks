using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float value)
    {
        slider.value = value / Player.playerHealth;
    }

}
